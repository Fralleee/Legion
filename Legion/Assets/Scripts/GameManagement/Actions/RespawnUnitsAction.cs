using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "Match/Actions/Respawn Units")]
public class RespawnUnitsAction : Action
{
  public override void Act(IStateController controller)
  {
    Respawn();
  }

  void Respawn()
  {
    GameManager.instance.PerformSpawnUnits();
  }
}
