using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "PluggableFSM/Decisions/ObjectiveAlive")]
public class ObjectiveAlive : Decision
{
  public override bool Decide(IStateController controller)
  {
    bool objectiveIsAlive = AliveCheck(controller);
    return objectiveIsAlive;
  }

  bool AliveCheck(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    GameObject target = ai.targeter.Objective;
    bool objectiveIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return objectiveIsAlive;
  }
}