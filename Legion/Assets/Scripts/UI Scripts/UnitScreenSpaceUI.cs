﻿using UnityEngine;

public class UnitScreenSpaceUI : MonoBehaviour
{
  DamageController damageController;
  ImageFillSetter healthBarValue;

  void Start()
  {
    damageController = GetComponent<DamageController>();
    healthBarValue = GetComponentInChildren<ImageFillSetter>();
    if(healthBarValue)
    {
      healthBarValue.Variable.ConstantValue = damageController.Health;
      healthBarValue.Max.ConstantValue = damageController.MaxHealth;
    }
  }

  void Update()
  {
    if (healthBarValue)
    {
      healthBarValue.Variable.ConstantValue = damageController.Health;
      healthBarValue.Max.ConstantValue = damageController.MaxHealth;
    }
  }

}
