using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ObjectiveAlive")]
public class ObjectiveAlive : AIDecision
{
  public override bool Decide(AIStateController controller)
  {
    bool objectiveIsAlive = AliveCheck(controller);
    return objectiveIsAlive;
  }

  bool AliveCheck(AIStateController ai)
  {
    GameObject target = ai.targeter.Objective;
    bool objectiveIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return objectiveIsAlive;
  }
}