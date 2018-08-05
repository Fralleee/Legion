using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TargetScanner
{
  public static bool FindHostiles(AITargeter targeter)
  {
    GameObject potentialTarget = null;
    int searchLayer = 1 << targeter.EnemyLayer;
    Collider[] validTargets = Physics.OverlapSphere(targeter.transform.position, targeter.LookRange, searchLayer);
    if (validTargets.Length > 0)
    {
      potentialTarget = PrioritizeByDistance(validTargets, targeter.transform.position);
      targeter.SetMainTarget(potentialTarget);
      targeter.SetCurrentTarget(potentialTarget);
      return true;
    }
    else
    {
      targeter.SetMainTarget(null);
      targeter.SetCurrentTarget(targeter.Objective);
      return false;
    }
  }

  public static GameObject FindTargets(this Ability ability, AITargeter targeter)
  {
    Vector3 currentPosition = targeter.transform.position;
    if (targeter.MainTarget && ability.IsMainAbility)
    {
      if (ability.RequireLineOfSight && Time.time > ability.lastLoSCheck)
      {
        ability.lastLoSCheck = Time.time + ability.losScanRate;
        bool inLineOfSight = ObjectInLineOfSight(targeter.MainTarget, currentPosition, ability.AbilityRange);
        if (inLineOfSight) return targeter.MainTarget;
      }
      else if (Vector3.Distance(targeter.MainTarget.transform.position, currentPosition) < ability.AbilityRange) return targeter.MainTarget;
      return null;
    }

    if (ability.targetType == TargetType.SELF) return ability.Caster;
    if ((Time.time < ability.lastTargetScan + ability.TargetScanRate)) return null;

    ability.lastTargetScan = Time.time;
    int searchLayer = 0;
    switch (ability.targetType)
    {
      case TargetType.FRIENDLY:
        searchLayer = 1 << targeter.gameObject.layer;
        break;
      case TargetType.HOSTILE:
        searchLayer = 1 << targeter.EnemyLayer;
        break;
    }

    Collider[] validTargets = Physics.OverlapSphere(currentPosition, ability.AbilityRange, searchLayer);
    if (ability.RequireLineOfSight && validTargets.Length > 0) validTargets = ObjectsInLineOfSight(validTargets, currentPosition, ability.AbilityRange);
    if (validTargets.Length > 0)
    {
      switch (ability.TargetPriority)
      {
        case TargetPriority.NEAREST:
          return PrioritizeByDistance(validTargets, currentPosition);
        case TargetPriority.LOWHEALTH:
          return PrioritizeByHealth(validTargets);
      }
    }
    return null;
  }

  public static bool ObjectInLineOfSight(Transform target, Vector3 position, float range)
  {
    Vector3 direction = target.position - position;
    RaycastHit hit;
    Debug.DrawRay(position.WithY(1.5f), direction, Color.red, 0.5f);
    if (Physics.Raycast(position.WithY(1.5f), direction, out hit, range))
    {
      return hit.collider.gameObject.layer == target.gameObject.layer;
    }
    return false;
  }
  public static Collider[] ObjectsInLineOfSight(Collider[] validTargets, Vector3 position, float range)
  {
    List<Collider> returnColliders = new List<Collider>();
    foreach (Collider col in validTargets)
    {
      var direction = col.transform.position - position;
      RaycastHit hit;
      if (Physics.Raycast(position, direction, out hit, range))
      {
        if (hit.collider.Equals(col)) returnColliders.Add(col);
      }
    }
    return returnColliders.ToArray();
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
