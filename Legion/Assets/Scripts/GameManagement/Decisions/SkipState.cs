using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Game/SkipState")]
public class SkipState : Decision
{
  public override bool Decide(IStateController controller)
  {
    return PerformSkip(controller);
  }

  bool PerformSkip(IStateController isc)
  {
    return GameManager.instance.skipState.Trigger();
  }

}