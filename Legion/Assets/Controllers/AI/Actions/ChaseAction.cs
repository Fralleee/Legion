using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Chase")]
public class ChaseAction : Action
{
  public override void Act(StateController controller)
  {
    Chase(controller);
  }

  void Chase(StateController controller)
  {
    if (!controller.targeter.CurrentTarget)
    {
      controller.navMeshAgent.isStopped = true;
      return;
    }
    controller.navMeshAgent.speed = controller.chasingSpeed;
    controller.navMeshAgent.SetDestination(controller.targeter.CurrentTarget.transform.position);
    controller.navMeshAgent.isStopped = false;
  }
}