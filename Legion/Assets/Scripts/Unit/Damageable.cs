using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
  [SerializeField] DefensiveStats inputStats;
  [SerializeField] float armor;
  [SerializeField] float health;
  float damageReduction;

  void Awake()
  {
    health = inputStats.health;
    armor = inputStats.armor;
    damageReduction = 1 - armor / 10;
  }

  public void TakeDamage(float damage, GameObject attacker)
  {
    float actualDamage = damage * damageReduction;
    health -= actualDamage;
    Debug.Log(gameObject.name + " took " + actualDamage + " damage!");

    if (health <= 0)
    {
      AIAction ai = attacker.GetComponent<AIAction>();
      if (ai) ai.ForceNewTarget();
      Die();
    }
  }

  void Die()
  {
    Debug.Log(gameObject.name + " died!");
    Destroy(gameObject);
  }

}
