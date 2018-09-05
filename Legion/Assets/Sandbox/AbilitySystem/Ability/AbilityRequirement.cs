using UnityEngine;

public enum RequirementType { All, Target, Casting }

public abstract class AbilityRequirement : ScriptableObject
{
  public RequirementType requirementType = RequirementType.All;
  public abstract bool Test(AbilityCaster caster, Ability ability, GameObject target, bool useSelfCast = false);
}
