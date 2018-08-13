using Fralle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TargetScanner
{
  public static GameObject FindTarget(Transform caster, float range, int layerMask, bool requireLineOfSight = false, TargetPriority targetPriority = TargetPriority.NEAREST)
  {
    Collider[] validTargets = Physics.OverlapSphere(caster.position, range, layerMask)
        .Where(x => !requireLineOfSight || LineOfSightLayer(x.transform, caster, range))
        .OrderBy(x => Vector3.SqrMagnitude(x.transform.position - caster.position))
        .ToArray();
    if (validTargets.Length > 0)
    {
      switch (targetPriority)
      {
        case TargetPriority.NEAREST:
          // Remake these
          return PrioritizeByDistance(validTargets, caster.position);
        case TargetPriority.LOWHEALTH:
          // Remake these
          return PrioritizeByHealth(validTargets);
      }
      return validTargets[0].gameObject;
    }
    return null;
  }
  public static bool FindHostilesLinq(AITargeter targeter)
  {
    int searchLayer = 1 << targeter.EnemyLayer;
    Collider[] validTargets = Physics.OverlapSphere(targeter.transform.position, targeter.LookRange, searchLayer);
    if (validTargets.Length > 0)
    {
      validTargets = validTargets
        .Where(x => LineOfSightLayer(x.transform, targeter.transform, targeter.LookRange))
        .OrderBy(x => Vector3.SqrMagnitude(x.transform.position - targeter.transform.position))
        .ToArray();
      if (validTargets.Length > 0)
      {
        targeter.SetMainTarget(validTargets[0].gameObject);
        targeter.SetCurrentTarget(validTargets[0].gameObject);
        return true;
      }
    }

    targeter.SetMainTarget(null);
    targeter.SetCurrentTarget(targeter.Objective);
    return false;
  }
  public static bool LineOfSightDirect(Transform caster, Transform target, float range)
  {
    Vector3 direction = target.position - caster.position;
    RaycastHit hit;
    Debug.DrawRay(caster.position.WithY(1.5f), direction, Color.red, 0.5f);
    if (Physics.Raycast(caster.position.WithY(1.5f), direction, out hit, range)) return hit.collider.gameObject == target.gameObject;
    return false;
  }
  public static bool LineOfSightLayer(Transform caster, Transform target, float range)
  {
    Vector3 direction = target.position - caster.position;
    RaycastHit hit;
    Debug.DrawRay(caster.position.WithY(1.5f), direction, Color.red, 0.5f);
    if (Physics.Raycast(caster.position.WithY(1.5f), direction, out hit, range)) return hit.collider.gameObject.layer == target.gameObject.layer;
    return false;
  }
  public static bool LineOfSightUnObstructed(Transform caster, Transform target, float range, int targetLayer, LayerMask targetMask, LayerMask obstacleMask)
  {
    Vector3 direction = target.position - caster.position;
    RaycastHit hit;
    Debug.DrawRay(caster.position.WithY(1.5f), direction, Color.red, 0.5f);
    if (Physics.Raycast(caster.position.WithY(1.5f), direction, out hit, range, targetMask | obstacleMask)) return hit.collider.gameObject.layer == targetLayer;
    return false;
  }
  public static GameObject PrioritizeByHealth(Collider[] validTargets)
  {
    GameObject bestTarget = null;
    float leastHealth = Mathf.Infinity;
    foreach (Collider potentialTarget in validTargets)
    {
      DamageController damageController = potentialTarget.GetComponent<DamageController>();
      if (damageController && damageController.PercentageHealth < 1)
      {
        if (damageController.Health < leastHealth)
        {
          leastHealth = damageController.Health;
          bestTarget = potentialTarget.gameObject;
        }
      }
    }
    return bestTarget;
  }
  public static GameObject PrioritizeByDistance(Collider[] validTargets, Vector3 currentPosition)
  {
    GameObject bestTarget = null;
    float closestDistanceSqr = Mathf.Infinity;
    foreach (Collider potentialTarget in validTargets)
    {
      float dSqrToTarget = Vector3.SqrMagnitude(potentialTarget.transform.position - currentPosition);
      if (dSqrToTarget < closestDistanceSqr)
      {
        closestDistanceSqr = dSqrToTarget;
        bestTarget = potentialTarget.gameObject;
      }
    }
    return bestTarget;
  }
}
