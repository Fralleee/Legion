using System.Collections;
using System.Collections.Generic;
using Fralle;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/Decisions/TargetInRange")]
public class TargetInRange : Decision
{
  public override bool Decide(IStateController controller)
  {
    bool targetInRange = IsTargetInRange(controller);
    return targetInRange;
  }

  bool IsTargetInRange(IStateController isc)
  {
    AIStateController ai = (AIStateController)isc;
    AITargeter targeter = ai.targeter;

    if (!targeter.mainTarget) return false;
    if (!targeter.PerformLoSCheck) return targeter.lastLosResult;

    targeter.lastLosCheck = Time.time + targeter.losCheckRate;
    AICaster caster = ai.caster;

    //if (caster.MainAbility.requireLineOfSight)
    //{
    //  targeter.lastLosResult = TargetScanner.LineOfSightLayer(caster.transform, targeter.MainTarget, caster.MainAbility.range);      
    //}
    //else
    //{
      targeter.lastLosResult = caster.MainAbility.range >= Vector3.Distance(targeter.mainTarget.transform.position, caster.transform.position) - targeter.mainTarget.Width;
    //}

    return targeter.lastLosResult;
  }
}