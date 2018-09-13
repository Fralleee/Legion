using UnityEngine;

[CreateAssetMenu(menuName = "Match/Units/Attributes")]
public class Attributes : ScriptableObject
{
  [Header("Offensive")]
  public float PhysicalPower;
  public float MagicalPower;

  [Header("Defensive")]
  public float MaxHealth = 1;
  public float Health = 1;
  public float Armor;

  [Header("Other")]
  public bool resetHealth;
}
