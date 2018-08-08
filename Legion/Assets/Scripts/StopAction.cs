using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Stop")]
public class StopAction : AIAction
{
  public override void Act(AIStateController controller)
  {
    Stop(controller);
  }

  void Stop(AIStateController ai)
  {
    ai.motor.navMeshAgent.isStopped = true;
  }
}