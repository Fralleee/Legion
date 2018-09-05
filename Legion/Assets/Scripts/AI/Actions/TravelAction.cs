using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "PluggableFSM/Actions/Travel")]
public class TravelAction : Action
{
  public override void Act(IStateController controller)
  {
    Travel(controller);
  }

  void Travel(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    ai.motor.Move(ai.targeter.currentTarget);
  }
}