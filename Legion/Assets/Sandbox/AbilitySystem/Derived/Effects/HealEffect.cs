using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Effects/Heal")]
public class HealEffect : AbilityEffect
{
  public int minAmount = 1;
  public int maxAmount = 1;

  public override void Affect(Ability ability, GameObject target)
  {
    base.Affect(ability, target);
    DamageController damageController = target.GetComponent<DamageController>();
    if (damageController)
    {
      System.Random rnd = new System.Random();
      int amount = rnd.Next(minAmount, maxAmount);
      damageController.ChangeHealth(amount, ability.owner.gameObject, ability.name);
    }
    else Debug.LogWarning("Target is missing DamageController: " + target.name);

  }
}
