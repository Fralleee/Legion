using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Effects/Damage")]
public class DamageEffect : ActionEffect
{
  public override void Affect(GameObject target, GameObject caster)
  {
    target.GetComponent<Damageable>().TakeDamage(caster.GetComponent<AIAction>().attackPower, caster);
  }
}
