using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/Attributes")]
public class Attributes : ScriptableObject
{
  [Header("Offensive")]
  public float physicalPower;
  public float magicalPower;

  [Header("Defensive")]
  public float health = 1;
  public float armor;
}
