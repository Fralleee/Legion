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
    if (ai.IsBlocked || !ai.targeter.CurrentTarget)
    {
      ai.motor.navMeshAgent.isStopped = true;
      return;
    }
    ai.motor.navMeshAgent.speed = ai.motor.chasingSpeed;
    ai.motor.navMeshAgent.SetDestination(ai.targeter.CurrentTarget.transform.position);
    ai.motor.navMeshAgent.isStopped = false;
  }
}