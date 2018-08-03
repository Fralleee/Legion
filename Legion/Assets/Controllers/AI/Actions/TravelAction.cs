using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Travel")]
public class TravelAction : Action
{
  public override void Act(StateController controller)
  {
    Travel(controller);
  }

  void Travel(StateController controller)
  {
    if (controller.IsBlocked || !controller.targeter.Objective)
    {
      controller.navMeshAgent.isStopped = true;
      return;
    }
    controller.navMeshAgent.speed = controller.travelSpeed;
    controller.navMeshAgent.SetDestination(controller.targeter.Objective.transform.position);
    controller.navMeshAgent.isStopped = false;
  }
}