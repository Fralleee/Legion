using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Effects/Damage")]
public class DamageEffect : AbilityEffect
{
  public override void Affect(Ability ability, GameObject target)
  {
    base.Affect(ability, target);
    DamageController damageController = target.GetComponent<DamageController>();
    System.Random rnd = new System.Random();
    float amount = rnd.Next(ability.MinAmount, ability.MaxAmount);
    damageController.TakeDamage(amount, ability.Caster, ability.AbilityName);

  }
}
