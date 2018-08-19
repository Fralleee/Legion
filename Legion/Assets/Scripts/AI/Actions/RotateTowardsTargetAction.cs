using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Actions/Rotate Towards Target")]
public class RotateTowardsTargetAction : Action
{
  public override void Act(IStateController controller)
  {
    Rotate(controller);
  }

  void Rotate(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    if (ai.targeter.CurrentTarget) ai.transform.LookAt(ai.targeter.CurrentTarget.transform);
  }
}