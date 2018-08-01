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
    controller.navMeshAgent.speed = controller.chasingSpeed;
    controller.navMeshAgent.SetDestination(controller.currentTarget.transform.position);
    controller.navMeshAgent.isStopped = false;
  }
}