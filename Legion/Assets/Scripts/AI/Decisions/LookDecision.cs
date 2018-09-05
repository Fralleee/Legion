﻿using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Decisions/Look")]
public class LookDecision : Decision
{
  public override bool Decide(IStateController controller)
  {
    bool foundHostile = Look(controller);
    return foundHostile;
  }

  bool Look(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    
    bool mainTargetAlive = ai.targeter.mainTarget && ai.targeter.mainTarget.gameObject && ai.targeter.mainTarget.gameObject.activeSelf;
    if (mainTargetAlive && ai.caster.MainAbility.lastAction + 4f > Time.time) return true;
    
    bool findHostilesResult = ai.targeter.FindTarget(ai.caster.MainAbility);
    if (findHostilesResult) ai.caster.MainAbility.lastAction = Time.time;
    Debug.Log(findHostilesResult);
    return findHostilesResult;
  }

}