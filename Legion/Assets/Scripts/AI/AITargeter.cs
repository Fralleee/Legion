using UnityEngine;

public class AITargeter : Targeter
{
  const float TargetScanRate = 0.5f;
  const int MinAggroRange = 15;
  const float LosCheckRate = 0.5f;
  public bool PerformLoSCheck { get { return Time.time > LastLosCheck; } }
  [HideInInspector] public float LastScan { get; set; }
  [HideInInspector] public float LastLosCheck { get; set; }
  [HideInInspector] public bool LastLosResult { get; set; }
  [HideInInspector] public float LookRange = 15f;

  public void SetAggroRange(int range) { LookRange = Mathf.Max(range, MinAggroRange); }
  public bool FindMainTarget(Ability ability)
  {
    if (!(Time.time > LastScan)) return mainTarget;
    if (mainTarget && !mainTarget.lookForNewTarget) return mainTarget;
    LastScan = Time.time + TargetScanRate;
    DamageController[] targets = TargetingHelpers.FindTargetsInRange(enemyLayerMask, LookRange, transform.position);
    if (targets.Length == 0) return false;
    targets = TargetingHelpers.OrderTargetsByPriority(targets, transform, ability.priority);
    mainTarget = new Target(targets[0].gameObject);
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
    if (!PerformLoSCheck) return LastLosResult;
    LastLosCheck = Time.time + LosCheckRate;
    LastLosResult = TargetingHelpers.LineOfSightUnObstructed(ability.owner.transform, mainTarget, ability.range, enemyLayerMask, environmentLayerMask);
    return LastLosResult;
  }
}
