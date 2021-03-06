﻿using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "AI/Actions/Travel")]
public class TravelAction : Action
{
  public override void Act(IStateController controller)
  {
    Travel(controller);
  }

  void Travel(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    ai.motor.TryMove(ai.targeter.currentTarget);
  }
}