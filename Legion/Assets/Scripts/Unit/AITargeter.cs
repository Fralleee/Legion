using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatisticsController))]
public class AITargeter : MonoBehaviour
{
  public AITargetingSettings targetingSettings;
  StatisticsController statisticsController;

  bool requireNewTarget { get { return Time.time > targetingSettings.lastAttack || (statisticsController.actionTarget == null && Time.time > targetingSettings.lastHostileScan); } }
  public bool hasLineOfSight { get; private set; }
  float lastLoSCheck;
  float losCheckBufferTime = 0.25f;
  LayerMask environmentLayerMask;

  void Start()
  {
    statisticsController = GetComponent<StatisticsController>();
    targetingSettings = Instantiate(targetingSettings);
    targetingSettings.enemyLayerMask = 1 << statisticsController.teamData.enemyLayer;
    environmentLayerMask = 1 << LayerMask.NameToLayer("Environment");
  }

  void Update()
  {
    if (requireNewTarget)
    {
      GameObject target = LookForTargetInRange();
      statisticsController.SetTarget(target);
    }
    CheckLineOfSight();
  }

  public void TargetDied() { statisticsController.ClearTarget(); }

  GameObject LookForTargetInRange()
  {
    targetingSettings.SetLastHostileScan();
    targetingSettings.SetLastAttack();
    Collider[] colliders = TargetFinder.FindTargetsWithDamageable(targetingSettings.enemyLayerMask, targetingSettings.hostileScanRange, transform.position);
    if (colliders.Length > 0)
    {
      if (statisticsController.actionTarget && colliders.Length > 1 && colliders[0].gameObject == statisticsController.actionTarget) return colliders[1].gameObject;
      return colliders[0].gameObject;
    }
    return null;
  }

  public void CheckLineOfSight()
  {
    if (Time.time > lastLoSCheck)
    {
      GameObject target = statisticsController.movementTarget;
      if (target == null)
      {
        hasLineOfSight = false;
        return;
      }

      float stoppingDistance = statisticsController.targetStats.stoppingDistance;
      if (Vector3.Distance(transform.position, target.transform.position) <= stoppingDistance)
      {
        Vector3 direction = target.transform.position - transform.position;
        lastLoSCheck = Time.time + losCheckBufferTime;
        Ray ray = new Ray(transform.position, target.transform.position - transform.position);
        Debug.DrawRay(transform.position, target.transform.position - transform.position, Color.red, 0.5f);
        hasLineOfSight = !Physics.SphereCast(ray, 0.5f, stoppingDistance, environmentLayerMask);
      }
    }
  }
}
