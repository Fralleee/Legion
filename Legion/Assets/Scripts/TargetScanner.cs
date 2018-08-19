using Fralle;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TargetScanner
{
  // Find
  public static GameObject FindTarget(Transform caster, float range, int layerMask, bool requireLineOfSight = false, TargetPriority targetPriority = TargetPriority.NEAREST)
  {
    Collider[] validTargets = Physics.OverlapSphere(caster.position, range, layerMask)
        .Where(x => !requireLineOfSight || LineOfSightLayer(x.transform, caster, range, "FindTarget"))
        .OrderBy(x => Vector3.SqrMagnitude(x.transform.position - caster.position))
        .ToArray();
    if (validTargets.Length > 0)
    {
      switch (targetPriority)
      {
        case TargetPriority.NEAREST:
          return PrioritizeByDistance(validTargets, caster.position);
        case TargetPriority.LOWHEALTH:
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
        .Where(x => LineOfSightLayer(x.transform, targeter.transform, targeter.LookRange, "FindHostilesLinq"))
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

  // Line of sight
  public static bool LineOfSightDirect(Transform caster, Transform target, float range)
  {
    if (target && caster)
    {
      Vector3 direction = target.position - caster.position;
      RaycastHit hit;
      Debug.DrawRay(caster.position.WithY(1.5f), direction, Color.red, 0.5f);
      if (Physics.Raycast(caster.position.WithY(1.5f), direction, out hit, range)) return hit.collider.gameObject == target.gameObject;
    }
    return false;
  }
  public static bool LineOfSightLayer(Transform caster, Transform target, float range, string temporary)
  {
    if (target && caster)
    {
      Vector3 direction = target.position - caster.position;
      RaycastHit hit;
      Debug.DrawRay(caster.position.WithY(1.5f), direction, Color.red, 0.5f);
      if (Physics.Raycast(caster.position.WithY(1.5f), direction, out hit, range))
      {
        return hit.collider.gameObject.layer == target.gameObject.layer;
      }
    }
    return false;
  }
  public static bool LineOfSightUnObstructed(Transform caster, Transform target, float range, int targetLayer, LayerMask targetMask, LayerMask obstacleMask)
  {
    if (target && caster)
    {
      Vector3 direction = target.position - caster.position;
      RaycastHit hit;
      Debug.DrawRay(caster.position.WithY(1.5f), direction, Color.red, 0.5f);
      if (Physics.Raycast(caster.position.WithY(1.5f), direction, out hit, range, targetMask | obstacleMask)) return hit.collider.gameObject.layer == targetLayer;
    }
    return false;
  }

  // Priority
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

  // Ability specific
  public static GameObject FindTargetForAbility(AIAbility ability, AITargeter targeter)
  {
    Vector3 currentPosition = targeter.transform.position;
    if (ability.targetType == TargetType.SELF) return targeter.gameObject;
    if ((Time.time < ability.lastTargetScan + ability.targetScanRate)) return null;
    ability.lastTargetScan = Time.time;
    int searchLayer = ability.targetType == TargetType.FRIENDLY ? 1 << targeter.gameObject.layer : 1 << targeter.EnemyLayer;
    return FindTarget(targeter.transform, ability.abilityRange, searchLayer, ability.requireLineOfSight, ability.targetPriority);
  }
  public static GameObject ValidateMainTarget(AIAbility ability, AITargeter targeter)
  {
    if (targeter.MainTarget)
    {
      if (ability.requireLineOfSight && Time.time > ability.lastLoSCheck)
      {
        ability.lastLoSCheck = Time.time + ability.losScanRate;
        bool inLineOfSight = LineOfSightLayer(targeter.MainTarget, targeter.transform, ability.abilityRange, "ValidateMainTarget/" + ability.abilityName);
        if (inLineOfSight) return targeter.MainTarget;
      }
      else if (Vector3.Distance(targeter.MainTarget.transform.position, targeter.transform.position) < ability.abilityRange) return targeter.MainTarget;
    }
    return null;
  }
}
