using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Effects/Movement Buff")]
public class MovementBuff : AbilityEffect
{
  public float amount = 1;
  public override void Affect(Ability ability, GameObject target)
  {
    base.Affect(ability, target);
    IMotor motor = target.GetComponent<IMotor>();
    if (motor != null) motor.ApplyModifier(amount);
    else Debug.LogWarning("Target is missing IMotor: " + target.name);

  }
}
