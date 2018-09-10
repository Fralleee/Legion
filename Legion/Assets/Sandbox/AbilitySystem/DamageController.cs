using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
  [SerializeField] Attributes attributes;
  [SerializeField] GameObject healthBar;

  [HideInInspector] public float Armor;
  [HideInInspector] public float Health;
  [HideInInspector] public float MaxHealth;

  public float PercentageHealth { get { return Health / MaxHealth; } }
  public event Action<float, float, bool> OnHealthChange = delegate { };

  float damageReduction;

  void Awake()
  {
    Armor = attributes.Armor;
    Health = attributes.Health;
    MaxHealth = attributes.MaxHealth;
    damageReduction = 1 - Armor / 10;
  }

  void Start()
  {
    OnHealthChange(Health, MaxHealth, false);
  }

  public void TakeDamage(float damage, GameObject attacker, string abilityName)
  {
    if (healthBar) healthBar.SetActive(true);
    float actualDamage = damage * damageReduction;
    Health -= actualDamage;

    if (Health > 0) OnHealthChange(Health, MaxHealth, true);
    else if (Health <= 0 && !attributes.resetHealth) Die();
    else if (attributes.resetHealth)
    {
      Health = MaxHealth;
      OnHealthChange(Health, MaxHealth, false);
    }
  }

  public void HealDamage(float amount, GameObject healer, string abilityName)
  {
    if (healthBar) healthBar.SetActive(true);
    float actualAmount = amount;
    Health += actualAmount;
    OnHealthChange(Mathf.Clamp(Health, 0, MaxHealth), MaxHealth, true);    
  }

  void Die()
  {
    Debug.Log(gameObject.name + " died!");
    Destroy(gameObject);
  }
}
