using UnityEngine;
using UnityEngine.AI;
using Fralle;

[CreateAssetMenu(menuName = "AI/Actions/Wander")]
public class WanderAction : Action
{
  public override void Act(IStateController controller)
  {
    Wander(controller);
  }

  void Wander(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;    
    ai.motor.wanderTimer += Time.deltaTime;
    if (ai.motor.wanderTimer < 5f) return;
    Vector3 newPos = RandomNavSphere(ai.transform.position, 10f, -1);      
    ai.motor.wanderTimer = 0;
    ai.motor.SimpleMove(newPos);
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