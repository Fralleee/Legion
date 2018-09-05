using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Game/Actions/Release Units")]
public class ReleaseUnitsAction : Action
{
  public override void Act(IStateController controller)
  {
    Release(controller);
  }

  void Release(IStateController isc)
  {
    GameManager.instance.PerformReleaseUnits();
  }
}
