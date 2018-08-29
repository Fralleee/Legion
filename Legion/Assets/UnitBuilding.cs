﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum UnitType
{
  TANK,
  WARRIOR,
  RANGED,
  ASSASSIN,
  CASTER,
  SIEGE
}

[CreateAssetMenu(menuName="Shop/Unit")]
public class UnitBuilding : ScriptableObject
{
  public UnitType type = UnitType.WARRIOR;
  public Sprite sprite;
  public float goldCost = 10;
  public float woodCost;
  public GameObject building;
  public GameObject unit;
  

}
