using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : Action
{
  public override void Act(StateController controller)
  {
    Wander(controller);
  }

  void Wander(StateController controller)
  {
    if (controller.IsBlocked)
    {
      controller.navMeshAgent.isStopped = true;
      return;
    }

    controller.navMeshAgent.speed = controller.travelSpeed;
    controller.navMeshAgent.isStopped = false;
    controller.wanderTimer += Time.deltaTime;
    if (controller.wanderTimer >= 5f)
    {
      Vector3 newPos = RandomNavSphere(controller.transform.position, 10f, -1);
      controller.navMeshAgent.SetDestination(newPos);
      controller.navMeshAgent.stoppingDistance = 0.5f;
      controller.wanderTimer = 0;
    }
  }
  
  Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
  {
    Vector3 randDirection = Random.insideUnitSphere * dist;
    randDirection += origin;
    NavMeshHit navHit;
    NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);
    return navHit.position;
  }
}