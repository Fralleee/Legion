using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "AI/Decisions/ObjectiveAlive")]
public class ObjectiveAlive : Decision
{
  public override bool Decide(IStateController controller)
  {
    bool objectiveIsAlive = AliveCheck(controller);
    return objectiveIsAlive;
  }

  bool AliveCheck(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    GameObject target = ai.targeter.objective;
    bool objectiveIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    return objectiveIsAlive;
  }
}