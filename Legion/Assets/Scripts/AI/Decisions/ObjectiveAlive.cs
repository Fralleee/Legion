using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/ObjectiveAlive")]
public class ObjectiveAlive : Decision
{
  public override bool Decide(StateController controller)
  {
    bool objectiveIsAlive = AliveCheck(controller);
    return objectiveIsAlive;
  }

  bool AliveCheck(StateController controller)
  {
    GameObject target = controller.targeter.Objective;
    bool objectiveIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return objectiveIsAlive;
  }
}