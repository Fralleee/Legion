using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(StatisticsController))]
public class DamageController : MonoBehaviour
{
  [SerializeField] Attributes attributes;
  [HideInInspector] public float Armor;
  [HideInInspector] public float Health;
  [HideInInspector] public float MaxHealth;
  float damageReduction;
  public float width;
  public float PercentageHealth { get { return Health / MaxHealth; } }

  void Awake()
  {
    Armor = attributes.Armor;
    Health = attributes.Health;
    MaxHealth = attributes.MaxHealth;
    damageReduction = 1 - Armor / 10;
  }

  public void TakeDamage(float damage, GameObject attacker)
  {
    float actualDamage = damage * damageReduction;
    Debug.Log(gameObject.name + " took " + actualDamage + " damage from " + attacker.name);
    Health -= actualDamage;
    if (Health <= 0)
    {
      Die();
    }
  }

  void Die()
  {
    Debug.Log(gameObject.name + " died!");
    Destroy(gameObject);
  }



}
