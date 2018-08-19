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
      targeter.lastLosResult = TargetScanner.LineOfSightLayer(targeter.MainTarget, caster.transform, caster.MainAbility.abilityRange, "TargetInRange.cs/" + caster.MainAbility.abilityName);
      if(targeter.lastLosResult && Vector3.Distance(targeter.MainTarget.transform.position, targeter.transform.position) > caster.MainAbility.abilityRange && caster.MainAbility.abilityRange < 4f)
      {
        if (targeter.LookRange <= 20)
        {
          Debug.Log(
          "Caster Name: " + caster.gameObject.name +
          ", Target Name: " + targeter.MainTarget.name +
          ", Distance: " + Vector3.Distance(targeter.MainTarget.transform.position, caster.transform.position) +
        ", Ability: " + caster.MainAbility.abilityName +
        ", Ability Range: " + caster.MainAbility.abilityRange +
        ", IsInLos: " + targeter.lastLosResult
        );
        }
      }
    }
    else
    {
      targeter.lastLosResult = caster.MainAbility.abilityRange >= Vector3.Distance(targeter.MainTarget.transform.position, caster.transform.position) - targeter.MainTarget.Width;
    }

    return targeter.lastLosResult;
  }
}