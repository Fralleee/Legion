using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
  public override bool Decide(StateController controller)
  {
    bool foundHostile = Look(controller);
    return foundHostile;
  }

  bool Look(StateController controller)
  {
    AITargeter targeter = controller.GetComponent<AITargeter>();
    bool mainTargetAlive = targeter.MainTarget && targeter.MainTarget.gameObject && targeter.MainTarget.gameObject.activeSelf;
    if (mainTargetAlive) return true;
    bool findHostilesResult = targeter.FindHostiles();
    return findHostilesResult;
  }

}