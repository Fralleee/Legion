using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "Match/Actions/Destroy Units")]
public class DestroyUnitsAction : Action
{
  public override void Act(IStateController controller)
  {
    Kill();
  }

  void Kill()
  {
    GameManager.instance.PerformDestroyUnits();
  }
}
