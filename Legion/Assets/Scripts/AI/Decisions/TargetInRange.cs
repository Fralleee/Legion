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

    if (!targeter.MainTarget) return false;
    if (!targeter.PerformLoSCheck) return targeter.lastLosResult;

    targeter.lastLosCheck = Time.time + targeter.losCheckRate;
    AICaster caster = ai.caster;

    if (caster.MainAbility.requireLineOfSight)
    {
      targeter.lastLosResult = TargetScanner.LineOfSightLayer(caster.transform, targeter.MainTarget, caster.MainAbility.abilityRange, caster.MainAbility);      
    }
    else
    {
      targeter.lastLosResult = caster.MainAbility.abilityRange >= Vector3.Distance(targeter.MainTarget.transform.position, caster.transform.position) - targeter.MainTarget.Width;
    }

    return targeter.lastLosResult;
  }
}