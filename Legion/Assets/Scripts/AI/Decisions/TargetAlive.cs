using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetAlive")]
public class TargetAlive : AIDecision
{
  public override bool Decide(AIStateController controller)
  {
    bool targetIsAlive = AliveCheck(controller);
    return targetIsAlive;
  }

  bool AliveCheck(AIStateController ai)
  {
    GameObject target = ai.targeter.CurrentTarget;
    bool targetIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return targetIsAlive;
  }
}