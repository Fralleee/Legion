using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Direct Action")]
public class DirectAction : UnitAction
{
  public override void Perform(GameObject target, GameObject caster)
  {
    base.Perform(target, caster);
    foreach (var effect in actionEffects)
    {
      effect.Affect(target, caster);
    }
  }
}
