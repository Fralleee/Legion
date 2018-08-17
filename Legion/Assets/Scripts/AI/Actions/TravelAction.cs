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
    if (ai.IsBlocked || !ai.targeter.Objective)
    {
      ai.motor.navMeshAgent.isStopped = true;
      return;
    }
    ai.motor.navMeshAgent.speed = ai.motor.travelSpeed;
    ai.motor.navMeshAgent.SetDestination(ai.targeter.Objective.transform.position);
    ai.motor.navMeshAgent.isStopped = false;
  }
}