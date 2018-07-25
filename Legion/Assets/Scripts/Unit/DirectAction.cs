using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Direct Action")]
public class DirectAction : UnitAction
{
  public override void Perform(GameObject target)
  {
    base.Perform(target);
    foreach (var effect in actionEffects)
    {
      effect.Affect(target, caster);
    }
  }
}
