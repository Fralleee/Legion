using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "Match/Actions/Release Units")]
public class ReleaseUnitsAction : Action
{
  public override void Act(IStateController controller)
  {
    Release();
  }

  void Release()
  {
    GameManager.instance.PerformReleaseUnits();
  }
}
