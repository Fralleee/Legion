using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Decisions/TargetAlive")]
public class TargetAlive : Decision
{
  public override bool Decide(IStateController controller)
  {
    bool targetIsAlive = AliveCheck(controller);
    return targetIsAlive;
  }

  bool AliveCheck(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    GameObject target = ai.targeter.CurrentTarget;
    bool targetIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return targetIsAlive;
  }
}