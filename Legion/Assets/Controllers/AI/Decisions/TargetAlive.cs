using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetAlive")]
public class TargetAlive : Decision
{
  public override bool Decide(StateController controller)
  {
    bool targetIsAlive = AliveCheck(controller);
    Debug.Log("Target is alive: " + targetIsAlive);
    return targetIsAlive;
  }

  bool AliveCheck(StateController controller)
  {
    GameObject target = controller.targeter.CurrentTarget;
    bool targetIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return targetIsAlive;
  }
}