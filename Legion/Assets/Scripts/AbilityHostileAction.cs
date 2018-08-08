using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AbilityHostile")]
public class AbilityHostileAction : AIAction
{
  public override void Act(AIStateController controller)
  {
    AbilityCast(controller);
  }

  void AbilityCast(AIStateController ai)
  {
    AICaster caster = ai.caster;
    if (!caster.IsBlocked)
    {
      foreach (Ability ability in caster.SecondaryAbilities.FindAll(x => x.targetType == TargetType.HOSTILE && x.IsReady))
      {
        if (caster.TryCast(ability)) return;
      }
      if(caster.MainAbility.IsReady) caster.TryCast(caster.MainAbility);
    }
  }
}