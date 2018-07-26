using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Effects/Damage")]
public class DamageEffect : ActionEffect
{
  public override void Affect(GameObject target, GameObject caster)
  {
    DamageController targetDamageable = target.GetComponent<DamageController>();
    StatisticsController statisticsController = caster.GetComponent<StatisticsController>();
    targetDamageable.TakeDamage(statisticsController.attributes.physicalPower, caster);
  }
}
