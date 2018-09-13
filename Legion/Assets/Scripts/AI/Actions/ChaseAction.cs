using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Actions/Chase")]
public class ChaseAction : Action
{
  public override void Act(IStateController controller)
  {
    Chase(controller);
  }

  void Chase(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    ai.motor.Move(ai.targeter.currentTarget, true);
  }
}