using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : AIDecision
{
  public override bool Decide(AIStateController controller)
  {
    bool foundHostile = Look(controller);
    return foundHostile;
  }

  bool Look(AIStateController ai)
  {
    AITargeter targeter = ai.targeter;
    bool mainTargetAlive = targeter.MainTarget && targeter.MainTarget.gameObject && targeter.MainTarget.gameObject.activeSelf;
    if (mainTargetAlive) return true;
    bool findHostilesResult = targeter.FindHostiles();
    return findHostilesResult;
  }

}