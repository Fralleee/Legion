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

    availableAbilities = availableAbilities.FindAll(x => IsTargetInRange(controller, controller.target, x.range));
    if (availableAbilities.Count == 0) return false;

    return true;
  }

  bool IsTargetInRange(StateController controller, Target target, float checkRange)
  {
    float distanceToTarget = Vector3.Distance(target.transform.position, controller.transform.position) - target.width;
    return checkRange >= distanceToTarget;
  }
}