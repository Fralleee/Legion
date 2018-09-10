using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "Match/Actions/Disable Building")]
public class DisableBuildingAction : Action
{
  public override void Act(IStateController controller)
  {
    Disable(controller);
  }

  void Disable(IStateController isc)
  {
    GameManager.instance.PerformDisableBuilding();
  }
}
