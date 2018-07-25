using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatisticsController))]
public class DamageController : MonoBehaviour
{
  [SerializeField] float armor;
  [SerializeField] float health;
  float damageReduction;

  void Awake()
  {
    StatisticsController statisticsController = GetComponent<StatisticsController>();
    health = statisticsController.defensiveStats.health;
    armor = statisticsController.defensiveStats.armor;
    damageReduction = 1 - armor / 10;
  }

  public void TakeDamage(float damage, GameObject attacker)
  {
    float actualDamage = damage * damageReduction;
    health -= actualDamage;
    Debug.Log(gameObject.name + " took " + actualDamage + " damage!");

    if (health <= 0)
    {
      AIActionController ai = attacker.GetComponent<AIActionController>();
      if (ai) ai.TargetDied();
      Die();
    }
  }

  void Die()
  {
    Debug.Log(gameObject.name + " died!");
    Destroy(gameObject);
  }

}
