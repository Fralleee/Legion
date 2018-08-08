using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetInRange")]
public class TargetInRange : Decision
{
  public override bool Decide(StateController controller)
  {
    bool targetInRange = IsTargetInRange(controller);
    return targetInRange;
  }

  bool IsTargetInRange(StateController controller)
  {
    AITargeter targeter = controller.targeter;

    if (!targeter.MainTarget) return false;
    if (!targeter.PerformLoSCheck) return targeter.lastLosResult;

    targeter.lastLosCheck = Time.time + targeter.losCheckRate;
    Vector3 currentPosition = controller.transform.position;
    AICaster caster = controller.caster;

    if (caster.MainAbility.RequireLineOfSight)
    {
      targeter.lastLosResult = TargetScanner.ObjectInLineOfSight(targeter.MainTarget, currentPosition, caster.MainAbility.AbilityRange);
    }
    else
    {
      targeter.lastLosResult = caster.MainAbility.AbilityRange >= Vector3.Distance(targeter.MainTarget.transform.position, currentPosition) - targeter.MainTarget.Width;
    }

    return targeter.lastLosResult;
  }
}