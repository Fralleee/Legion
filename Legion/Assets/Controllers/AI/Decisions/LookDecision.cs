using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
  [SerializeField] Color losColor = Color.red;
  public override bool Decide(StateController controller)
  {
    bool targetInSight = Look(controller);
    Debug.Log("Target in sight: " + targetInSight);
    return targetInSight;
  }

  bool Look(StateController controller)
  {
    Collider[] colliders = FindTargetsWithDamageable(controller.enemyLayerMask, controller.lookRange, controller.transform.position);
    foreach (Collider collider in colliders)
    {
      RaycastHit hit;
      if (HasLineOfSight(controller, collider.gameObject, out hit, controller.lookRange, controller.environmentLayerMask | controller.enemyLayerMask))
      {
        if (hit.transform.gameObject.layer == controller.teamData.enemyLayer)
        {
          controller.currentTarget = new Target(hit.transform);
          return true;
        }        
      }
    }
    return false;
  }

  Collider[] FindTargetsWithDamageable(LayerMask layerMask, float maxRange, Vector3 position)
  {
    Collider[] colliders = Physics.OverlapSphere(position, maxRange, layerMask);
    return colliders
      .Where(x => x.GetComponent<DamageController>())
      .OrderBy(x => (x.transform.position - position).sqrMagnitude)
      .ToArray();
  }

  bool HasLineOfSight(StateController controller, GameObject target, out RaycastHit hit, float range, LayerMask layerMask)
  {
    Ray ray = new Ray(controller.eyes.position, target.transform.position - controller.eyes.position);
    Debug.DrawRay(controller.eyes.position, target.transform.position - controller.eyes.position, losColor, 0.5f);
    return Physics.Raycast(ray, out hit, range, layerMask);
  }

  bool HasLineOfSightRadius(StateController controller, GameObject target, out RaycastHit hit, float range, float sphereCastRadius, LayerMask layerMask)
  {
    Ray ray = new Ray(controller.eyes.position, target.transform.position - controller.eyes.position);
    Debug.DrawRay(controller.eyes.position, target.transform.position - controller.eyes.position, losColor, 0.5f);
    return Physics.SphereCast(ray, sphereCastRadius, out hit, range, layerMask);
  }
}