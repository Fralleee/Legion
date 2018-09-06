using System.Collections;
using System.Collections.Generic;
using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Decisions/TargetInRange")]
public class TargetInRange : Decision
{
  public override bool Decide(IStateController controller)
  {
    bool targetInRange = IsTargetInRange(controller);
    return targetInRange;
  }

  bool IsTargetInRange(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    AITargeter targeter = ai.targeter;

    if (!targeter.mainTarget)
    {
      return false;
    }

    bool lineOfSight = targeter.LineOfSightMainTarget(ai.caster.mainAttack);
    return lineOfSight;
  }
}