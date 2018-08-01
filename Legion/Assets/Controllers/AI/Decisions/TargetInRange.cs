using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Decisions/TargetInRange")]
public class TargetInRange : Decision
{
  public override bool Decide(StateController controller)
  {
    bool targetInRange = InRange(controller);
    return targetInRange;
  }

  bool InRange(StateController controller)
  {
    List<Ability> availableAbilities = controller.hostileAbilities.FindAll(x => !x.onCooldown);
    if (availableAbilities.Count == 0) return false;

    availableAbilities = availableAbilities.FindAll(x => IsTargetInRange(controller.transform, controller.target, controller.targetWidth, x.range));
    if (availableAbilities.Count == 0) return false;

    return true;
  }

  bool IsTargetInRange(Transform origin, Target target, float targetWidth, float checkRange)
  {
    float distanceToTarget = Vector3.Distance(target.position, origin.position) - target.width;
    return checkRange >= distanceToTarget;
  }
}