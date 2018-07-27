using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatisticsController))]
public class AITargeter : MonoBehaviour
{
  [SerializeField] float targetSwitchEvaluationTime = 4f;
  [SerializeField] float targetScanCooldown = 1f;
  [SerializeField] float lineOfSightCheckCooldown = 0.25f;
  [Range(15, 100)] [SerializeField] float hostileScanRange = 15f;

  public bool hasLineOfSight { get; private set; }
  public float lastInteractionWithTarget { get; private set; }
  public float lastHostileScan { get; private set; }

  StatisticsController statisticsController;
  int environmentLayer;
  LayerMask environmentLayerMask;
  LayerMask enemyLayerMask;
  float lastLineOfSightCheck;
  bool requireNewTarget { get { return Time.time > lastInteractionWithTarget || (statisticsController.actionTarget == null && Time.time > lastHostileScan); } }

  void Start()
  {
    statisticsController = GetComponent<StatisticsController>();
    environmentLayer = LayerMask.NameToLayer("Environment");
    enemyLayerMask = 1 << statisticsController.teamData.enemyLayer;
    environmentLayerMask = 1 << environmentLayer;
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
  GameObject LookForTargetInRange()
  {
    SetLastHostileScan();
    SetLastInteractionWithTarget();
    Collider[] colliders = TargetFinder.FindTargetsWithDamageable(enemyLayerMask, hostileScanRange, transform.position);
    if (colliders.Length > 0)
    {
      foreach (Collider collider in colliders)
      {
        RaycastHit hit;
        if (TargetFinder.HasLineOfSight(gameObject, collider.gameObject, out hit, hostileScanRange, environmentLayerMask | enemyLayerMask))
        {
          if (hit.transform.gameObject.layer == statisticsController.teamData.enemyLayer) return collider.gameObject;
        }
      }
    }
    return null;
  }

  public void SetLastInteractionWithTarget(float extraTime = 0) { lastInteractionWithTarget = Time.time + extraTime + targetSwitchEvaluationTime; }
  public void SetHostileScanRange(float maxRangeInActions) { hostileScanRange = Mathf.Clamp(Mathf.Max(hostileScanRange, maxRangeInActions), 15, 100); }
  public void SetLastHostileScan() { lastHostileScan = Time.time + targetScanCooldown; }
  public void TargetDied() { statisticsController.ClearTarget(); }
  public void CheckLineOfSight()
  {
    if (Time.time > lastLineOfSightCheck)
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
        lastLineOfSightCheck = Time.time + lineOfSightCheckCooldown;
        RaycastHit hit;
        if (TargetFinder.HasLineOfSightRadius(gameObject, target, out hit, stoppingDistance, 0.5f, environmentLayerMask | enemyLayerMask))
        {
          hasLineOfSight = hit.transform.gameObject.layer != environmentLayer;
        }
      }
    }
  }

}
