using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Attributes")]
public class Attributes : ScriptableObject
{
  [Header("Offensive")]
  public float PhysicalPower;
  public float MagicalPower;

  [Header("Defensive")]
  public float MaxHealth = 1;
  public float Health = 1;
  public float Armor;
}
