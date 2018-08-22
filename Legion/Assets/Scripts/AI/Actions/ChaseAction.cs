using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Actions/Chase")]
public class ChaseAction : Action
{
  public override void Act(IStateController controller)
  {
    Chase(controller);
  }

  void Chase(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    ai.motor.Move(ai.targeter.CurrentTarget, true);
  }
}