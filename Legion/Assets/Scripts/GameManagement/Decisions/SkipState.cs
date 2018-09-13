using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "Match/SkipState")]
public class SkipState : Decision
{
  public override bool Decide(IStateController controller)
  {
    return PerformSkip();
  }

  bool PerformSkip()
  {
    return GameManager.instance.skipState.Trigger();
  }

}