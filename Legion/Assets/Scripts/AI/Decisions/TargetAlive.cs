using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "AI/Decisions/TargetAlive")]
public class TargetAlive : Decision
{
  public override bool Decide(IStateController controller)
  {
    bool targetIsAlive = AliveCheck(controller);
    return targetIsAlive;
  }

  bool AliveCheck(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    GameObject target = ai.targeter.currentTarget;
    bool targetIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return targetIsAlive;
  }
}