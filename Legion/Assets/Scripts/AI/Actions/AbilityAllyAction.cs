using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "AI/Actions/AbilityAlly")]
public class AbilityAllyAction : Action
{
  public override void Act(IStateController controller)
  {
    AbilityCast(controller);
  }

  void AbilityCast(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    AICaster caster = ai.caster;
    if (caster.isBlocked) return;
    foreach (Ability ability in caster.abilities.FindAll(x => x.targetTeam == AbilityTargetTeam.Ally && x.isReady))
    {
      if (!caster.TryCast(ability)) continue;
      ability.Cast();
      return;
    }
  }
}