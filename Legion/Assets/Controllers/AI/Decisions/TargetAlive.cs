using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetAlive")]
public class TargetAlive : Decision
{
  public override bool Decide(StateController controller)
  {
    bool targetIsAlive = controller.currentTarget.transform.gameObject.activeSelf;
    return targetIsAlive;
  }
}