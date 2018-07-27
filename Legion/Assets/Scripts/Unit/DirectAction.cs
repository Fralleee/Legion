using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Direct Action")]
public class DirectAction : Ability
{
  public override void Perform(GameObject target)
  {
    base.Perform(target);
    foreach (var effect in abilityEffects)
    {
      effect.Affect(target, caster);
    }
  }
}
