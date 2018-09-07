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
    if (!caster.isBlocked)
    {
      foreach (Ability ability in caster.abilities.FindAll(x => x.targetTeam == AbilityTargetTeam.Hostile && x.isReady))
      {
        if (caster.TryCast(ability)) return;
      }

      if (caster.mainAttack.isReady)
      {
        Debug.Log("Casting mainAttack");
        caster.mainAttack.Cast(false);
      }
      else if (caster.secondaryAttack && caster.secondaryAttack.isReady)
      {
        Debug.Log("Casting secondaryAttack");
        caster.secondaryAttack.Cast(false);
      }

    }
  }
}