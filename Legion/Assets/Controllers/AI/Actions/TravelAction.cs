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
    controller.navMeshAgent.speed = controller.travelSpeed;
    controller.navMeshAgent.SetDestination(controller.objective.transform.position);
    controller.navMeshAgent.isStopped = false;
  }
}