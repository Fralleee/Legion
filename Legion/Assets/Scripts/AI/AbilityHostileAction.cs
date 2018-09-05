﻿using UnityEngine;
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
      if (caster.MainAbility.isReady) caster.TryCast(caster.MainAbility);
    }
  }
}