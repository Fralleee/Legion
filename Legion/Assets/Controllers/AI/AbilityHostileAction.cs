using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/Actions/AbilityHostile")]
public class AbilityHostileAction : Action
{
  public override void Act(StateController controller)
  {
    AbilityCast(controller);
  }

  void AbilityCast(StateController controller)
  {
    AICaster caster = controller.GetComponent<AICaster>();
    if (!caster.IsBlocked)
    {
      foreach (Ability ability in caster.SecondaryAbilities.FindAll(x => x.targetType == TargetType.HOSTILE))
      {
        if (caster.TryCast(ability))
        {
          return;
        }
      }

      caster.TryCast(caster.MainAbility);
    }
  }
}