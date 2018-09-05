using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Game/Actions/Respawn Units")]
public class RespawnUnitsAction : Action
{
  public override void Act(IStateController controller)
  {
    Respawn(controller);
  }

  void Respawn(IStateController isc)
  {
    GameManager.instance.PerformSpawnUnits();
  }
}
