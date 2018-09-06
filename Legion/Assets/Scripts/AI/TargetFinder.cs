using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TargetingHelpers
{
  /// <summary>
  /// A physics overlapsphere which fetches all DamageControllers hit
  /// </summary>
  /// <param name="layerMask"></param>
  /// <param name="maxRange"></param>
  /// <param name="position"></param>
  /// <returns></returns>
  public static DamageController[] FindTargetsInRange(LayerMask layerMask, float maxRange, Vector3 position)
  {
    Collider[] colliders = Physics.OverlapSphere(position, maxRange, layerMask);
    DamageController[] targets = colliders.Where(x => x.GetComponent<DamageController>()).Select(x => x.GetComponent<DamageController>()).ToArray();
    return targets;
  }

  /// <summary>
  /// Input an array of DamageControllers and TargetPriority and get an ordered array out
  /// which could be used to check for Line of sight
  /// </summary>
  /// <param name="array"></param>
  /// <param name="transform"></param>
  /// <param name="priority"></param>
  /// <returns></returns>
  public static DamageController[] OrderTargetsByPriority(DamageController[] array, Transform transform, AbilityPriority priority = AbilityPriority.None)
  {
    switch (priority)
    {
      case AbilityPriority.None: return array;
      case AbilityPriority.Nearest: return array.OrderBy(x => (x.transform.position - transform.position).sqrMagnitude).ToArray();
      case AbilityPriority.Furthest: return array.OrderByDescending(x => (x.transform.position - transform.position).sqrMagnitude).ToArray();
      case AbilityPriority.LowHealth: return array.OrderBy(x => x.Health).ToArray();
      case AbilityPriority.HighHealth: return array.OrderByDescending(x => x.Health).ToArray();
      default: return array;
    }
  }

  /// <summary>
  /// Validates array and ability and returnes a target if matched
  /// </summary>
  /// <param name="array"></param>
  /// <param name="transform"></param>
  /// <param name="ability"></param>
  /// <returns></returns>
  public static DamageController ValidateTargetsLineOfSight(DamageController[] array, Transform transform, Ability ability)
  {
    LayerMask targetMask = 1 << ability.targetLayer;
    LayerMask environmentMask = 1 << ability.environmentLayer;
    switch (ability.requireLineOfSight)
    {
      case AbilityLineOfSight.Target: return array.First(x => LineOfSightUnObstructed(transform, x.transform, ability.range, targetMask, environmentMask));
      case AbilityLineOfSight.Team: return array.First(x => LineOfSightLayer(transform, x.transform, ability.range, targetMask, environmentMask));
      case AbilityLineOfSight.NotRequired: return array.First();
      default: return null;
    }
  }



  /// <summary>
  /// Basically return true if we have line of sight from same team we're trying to hit
  /// Useful for AOE spells in which we just want the AI to do damage
  /// </summary>
  /// <param name="caster"></param>
  /// <param name="target"></param>
  /// <param name="range"></param>
  /// <returns></returns>
  public static bool LineOfSightLayer(Transform caster, Transform target, float range, LayerMask targetMask, LayerMask environmentMask)
  {
    if (!target || !caster) return false;
    Vector3 direction = target.position - caster.position;
    RaycastHit hit;
    Debug.DrawRay(caster.position, direction, Color.red, 0.5f);
    if (Physics.Raycast(caster.position, direction, out hit, range, targetMask | environmentMask)) return hit.collider.gameObject.layer == target.gameObject.layer;
    return false;
  }

  /// <summary>
  /// We perform a check on Environment and Target layer to see if we are obstructed by a static wall or something like that.
  /// Otherwise we might be obstructed by something that should not block or line of sight (other ability, fire, clouds)
  /// </summary>
  /// <param name="caster"></param>
  /// <param name="target"></param>
  /// <param name="range"></param>
  /// <param name="targetLayer"></param>
  /// <param name="targetMask"></param>
  /// <param name="obstacleMask"></param>
  /// <returns></returns>
  public static bool LineOfSightUnObstructed(Transform caster, Transform target, float range, LayerMask targetMask, LayerMask environmentMask)
  {
    if (!target || !caster) return false;
    Vector3 direction = target.position - caster.position;
    RaycastHit hit;
    Debug.DrawRay(caster.position, direction, Color.red, 0.5f);
    if (Physics.Raycast(caster.position, direction, out hit, range, targetMask | environmentMask)) return hit.collider.gameObject == target.gameObject;
    return false;
  }
}
