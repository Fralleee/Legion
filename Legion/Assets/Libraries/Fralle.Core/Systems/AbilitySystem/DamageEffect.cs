﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Effects/Damage")]
public class DamageEffect : AbilityEffect
{
  public override void Affect(GameObject target, GameObject caster)
  {
    Debug.Log("Affect");
    DamageController targetDamageable = target.GetComponent<DamageController>();
    StatisticsController statisticsController = caster.GetComponent<StatisticsController>();
    targetDamageable.TakeDamage(statisticsController.attributes.physicalPower, caster);
  }
}