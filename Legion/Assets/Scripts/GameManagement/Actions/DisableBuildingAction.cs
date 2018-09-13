using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "Match/Actions/Disable Building")]
public class DisableBuildingAction : Action
{
  public override void Act(IStateController controller)
  {
    Disable();
  }

  void Disable()
  {
    GameManager.instance.PerformDisableBuilding();
  }
}
