using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "PluggableAI/Actions/Wander")]
public class WanderAction : AIAction
{
  public override void Act(AIStateController controller)
  {
    Wander(controller);
  }

  void Wander(AIStateController ai)
  {
    if (ai.motor.IsBlocked)
    {
      ai.motor.navMeshAgent.isStopped = true;
      return;
    }

    ai.motor.navMeshAgent.speed = ai.motor.travelSpeed;
    ai.motor.navMeshAgent.isStopped = false;
    ai.motor.wanderTimer += Time.deltaTime;
    if (ai.motor.wanderTimer >= 5f)
    {
      Vector3 newPos = RandomNavSphere(ai.transform.position, 10f, -1);
      ai.motor.navMeshAgent.SetDestination(newPos);
      ai.motor.navMeshAgent.stoppingDistance = 0.5f;
      ai.motor.wanderTimer = 0;
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