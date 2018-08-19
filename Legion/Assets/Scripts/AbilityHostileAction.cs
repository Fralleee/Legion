using UnityEngine;
using Fralle;

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
      foreach (AIAbility ability in caster.SecondaryAbilities.FindAll(x => x.targetType == TargetType.HOSTILE && x.isReady))
      {
        if (caster.TryCast(ability))
        {
          return;
        }
      }
      if (caster.MainAbility.isReady)
      {
        caster.TryCast();
      }
    }
  }
}