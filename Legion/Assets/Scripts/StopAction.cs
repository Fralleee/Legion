using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Stop")]
public class StopAction : Action
{
  public override void Act(StateController controller)
  {
    Stop(controller);
  }

  void Stop(StateController controller)
  {
    controller.navMeshAgent.isStopped = true;
  }
}