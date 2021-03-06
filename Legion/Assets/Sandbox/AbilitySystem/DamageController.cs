﻿using System;
using UnityEngine;

public class DamageController : MonoBehaviour
{
  [SerializeField] Attributes attributes;
  [SerializeField] GameObject healthBar;
  [HideInInspector] public Renderer model;
  [HideInInspector] public float Armor;
  [HideInInspector] public float Health;
  [HideInInspector] public float MaxHealth;

  public float PercentageHealth { get { return Health / MaxHealth; } }
  public event Action<float, float, bool> OnHealthChange = delegate { };

  float damageReduction;

  void Awake()
  {
    model = GetComponentInChildren<Renderer>();
    Armor = attributes.Armor;
    Health = attributes.Health;
    MaxHealth = attributes.MaxHealth;
    damageReduction = 1 - Armor / 10;
  }

  void Start()
  {
    OnHealthChange(Health, MaxHealth, false);
  }

  public void ChangeHealth(float amount, GameObject affector, string abilityName)
  {
    if (healthBar) healthBar.SetActive(true);

    if(amount < 0) amount = amount * damageReduction;
    Health += amount;

    if (Health > 0) OnHealthChange(Health, MaxHealth, true);
    else if (Health <= 0 && !attributes.resetHealth) Die();
    else if (attributes.resetHealth)
    {
      Health = MaxHealth;
      OnHealthChange(Health, MaxHealth, false);
    }
  }

  void Die()
  {
    Debug.Log(gameObject.name + " died!");
    Destroy(gameObject);
  }
}
