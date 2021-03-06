﻿using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "AI/Actions/AbilityHostile")]
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
    if (caster.isBlocked) return;
    foreach (Ability ability in caster.abilities.FindAll(x => x.targetTeam == AbilityTargetTeam.Hostile && x.isReady))
    {
      if (!caster.TryCast(ability)) continue;
      ability.Cast();
      return;
    }

    if (caster.mainAttack.isReady && caster.TryCastMainTarget(caster.mainAttack))
    {
      ai.targeter.currentTarget = ai.targeter.mainTarget;
      caster.mainAttack.Cast();
    }
    else if (caster.secondaryAttack && caster.secondaryAttack.isReady && caster.TryCastMainTarget(caster.secondaryAttack))
    {
      ai.targeter.currentTarget = ai.targeter.mainTarget;
      caster.secondaryAttack.Cast();
    }
  }
}