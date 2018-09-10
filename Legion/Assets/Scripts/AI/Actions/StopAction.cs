﻿using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Stop")]
public class StopAction : Action
{
  public override void Act(IStateController controller)
  {
    Stop(controller);
  }

  void Stop(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    ai.motor.Stop(ai.targeter.currentTarget);
  }
}