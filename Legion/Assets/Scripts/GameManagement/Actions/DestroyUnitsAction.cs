using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Game/Actions/Destroy Units")]
public class DestroyUnitsAction : Action
{
  public override void Act(IStateController controller)
  {
    Kill(controller);
  }

  void Kill(IStateController isc)
  {
    GameManager.instance.PerformDestroyUnits();
  }
}
