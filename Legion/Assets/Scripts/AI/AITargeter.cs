using UnityEngine;
using Fralle;

public class AITargeter : MonoBehaviour, ITargeter
{
  const float TARGET_SCAN_RATE = 0.5f;
  const int MIN_AGGRO_RANGE = 15;
  const float LOS_CHECK_RATE = 0.5f;

  public Target currentTarget { get; set; }
  public Target mainTarget { get; set; }
  public Target objective { get; set; }
  public bool PerformLoSCheck { get { return Time.time > lastLosCheck; } }
  [HideInInspector] public float lastScan { get; set; }
  [HideInInspector] public float lastLosCheck { get; set; }
  [HideInInspector] public bool lastLosResult { get; set; }

  [Header("Layer masks")]
  public LayerMask EnvironmentLayerMask;
  public LayerMask EnemyLayerMask;
  public int EnemyLayer;

  [HideInInspector] public float LookRange = 15f;

  public int GetTargetLayer(AbilityTargetTeam targetTeam) { return targetTeam == AbilityTargetTeam.Hostile ? EnemyLayer : gameObject.layer; }
  public void SetAggroRange(int range) { LookRange = Mathf.Max(range, MIN_AGGRO_RANGE); }
  public bool FindMainTarget(Ability ability)
  {
    if (Time.time > lastScan)
    {
      if (!mainTarget || mainTarget.lookForNewTarget)
      {
        lastScan = Time.time + TARGET_SCAN_RATE;
        DamageController[] targets = TargetingHelpers.FindTargetsInRange(EnemyLayerMask, LookRange, transform.position);
        if (targets.Length == 0) return false;
        targets = TargetingHelpers.OrderTargetsByPriority(targets, transform, ability.priority);
        mainTarget = new Target(targets[0].gameObject);
        currentTarget = mainTarget;

      }
    }
    return mainTarget;
  }
  public bool FindTarget(Ability ability)
  {
    DamageController[] targets = TargetingHelpers.FindTargetsInRange(1 << ability.targetLayer, ability.range, transform.position);
    targets = TargetingHelpers.CheckRequirements(targets, ability.targetRequirement);
    if (targets.Length == 0) return false;

    targets = TargetingHelpers.OrderTargetsByPriority(targets, transform, ability.priority);
    DamageController target = TargetingHelpers.ValidateTargetsLineOfSight(targets, transform, ability);
    if (!target) return false;
    currentTarget = new Target(target.gameObject);
    return true;
  }

  public bool LineOfSightMainTarget(Ability ability)
  {
    if (PerformLoSCheck)
    {
      lastLosCheck = Time.time + LOS_CHECK_RATE;
      lastLosResult = TargetingHelpers.LineOfSightUnObstructed(ability.owner.transform, mainTarget, ability.range, EnemyLayerMask, EnvironmentLayerMask);
    }
    return lastLosResult;
  }
}
