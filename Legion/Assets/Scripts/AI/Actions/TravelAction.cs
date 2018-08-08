using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Travel")]
public class TravelAction : AIAction
{
  public override void Act(AIStateController controller)
  {
    Travel(controller);
  }

  void Travel(AIStateController ai)
  {
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