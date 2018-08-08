using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Actions/AbilityHostile")]
public class AbilityHostileAction : Action
{
  public override void Act(IStateController controller)
  {
    AbilityCast(controller);
  }

  void AbilityCast(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
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