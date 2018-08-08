using Fralle;
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
    AITargeter targeter = ai.targeter;
    bool mainTargetAlive = targeter.MainTarget && targeter.MainTarget.gameObject && targeter.MainTarget.gameObject.activeSelf;
    if (mainTargetAlive) return true;
    bool findHostilesResult = targeter.FindHostiles();
    return findHostilesResult;
  }

}