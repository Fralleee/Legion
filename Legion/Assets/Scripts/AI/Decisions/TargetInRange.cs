﻿using System.Collections;
using System.Collections.Generic;
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

    if (caster.MainAbility.RequireLineOfSight)
    {
      targeter.lastLosResult = TargetScanner.LineOfSightLayer(targeter.MainTarget, caster.transform, caster.MainAbility.AbilityRange);
    }
    else
    {
      targeter.lastLosResult = caster.MainAbility.AbilityRange >= Vector3.Distance(targeter.MainTarget.transform.position, caster.transform.position) - targeter.MainTarget.Width;
    }

    return targeter.lastLosResult;
  }
}