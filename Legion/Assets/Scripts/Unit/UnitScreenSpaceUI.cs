using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitScreenSpaceUI : MonoBehaviour
{
  StatisticsController statisticsController;
  DamageController damageController;
  ImageFillSetter healthBarValue;

  void Start()
  {
    statisticsController = GetComponent<StatisticsController>();
    damageController = GetComponent<DamageController>();
    healthBarValue = GetComponentInChildren<ImageFillSetter>();
    if(healthBarValue)
    {
      healthBarValue.Variable.ConstantValue = damageController.health;
      healthBarValue.Max.ConstantValue = damageController.maxHealth;
    }
  }

  void Update()
  {
    if (healthBarValue)
    {
      healthBarValue.Variable.ConstantValue = damageController.health;
      healthBarValue.Max.ConstantValue = damageController.maxHealth;
    }
  }

}
