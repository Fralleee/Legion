using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(StatisticsController))]
public class DamageController : MonoBehaviour
{
  [SerializeField] Attributes attributes;
  [HideInInspector] public float armor;
  [HideInInspector] public float health;
  [HideInInspector] public float maxHealth;
  float damageReduction;

  public float width;

  void Awake()
  {
    //StatisticsController statisticsController = GetComponent<StatisticsController>();
    //health = statisticsController.attributes.health;
    //maxHealth = statisticsController.attributes.health;
    //armor = statisticsController.attributes.armor;
    //damageReduction = 1 - armor / 10;

    health = attributes.health;
    maxHealth = attributes.health;
    armor = attributes.armor;
    damageReduction = 1 - armor / 10;

    width = GetComponent<Collider>().bounds.size.x / 2;
  }

  public void TakeDamage(float damage, GameObject attacker)
  {
    float actualDamage = damage * damageReduction;
    health -= actualDamage;
    if (health <= 0)
    {
      //AITargeter ai = attacker.GetComponent<AITargeter>();
      //if (ai) ai.ClearDeadTarget(gameObject);
      Die();
    }
  }

  void Die()
  {
    Debug.Log(gameObject.name + " died!");
    Destroy(gameObject);
  }

}
