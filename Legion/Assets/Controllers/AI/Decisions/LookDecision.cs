using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/Look")]
public class LookDecision : Decision
{
  public override bool Decide(StateController controller)
  {
    return Look(controller);
  }

  bool Look(StateController controller)
  {
    AITargeter targeter = controller.GetComponent<AITargeter>();
    if (targeter.MainTarget) return true;
    return targeter.FindHostiles();
  }

}