using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "Match/Actions/Enable Building")]
public class EnableBuildingAction : Action
{
  public override void Act(IStateController controller)
  {
    Enable();
  }

  void Enable()
  {
    GameManager.instance.PerformEnableBuilding();
  }
}
