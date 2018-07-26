using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatisticsController))]
public class DamageController : MonoBehaviour
{
  [SerializeField] float armor;
  [SerializeField] float health;
  float maxHealth;
  float damageReduction;

  Renderer healthBarRenderer;

  void Awake()
  {
    StatisticsController statisticsController = GetComponent<StatisticsController>();
    health = statisticsController.defensiveStats.health;
    maxHealth = statisticsController.defensiveStats.health;
    armor = statisticsController.defensiveStats.armor;
    damageReduction = 1 - armor / 10;
    InitializeHealthBar();
  }

  void InitializeHealthBar()
  {
    var healthBarTransform = transform.Find("HealthBar");
    if (healthBarTransform) healthBarRenderer = healthBarTransform.GetComponent<Renderer>();
    if (healthBarRenderer)
    {
      healthBarRenderer.material.shader = Shader.Find("Custom/HealthBarShader");
      healthBarRenderer.material.SetFloat("_ScaleX", gameObject.transform.localScale.x + 1f);
      healthBarRenderer.material.SetFloat("_Point", Mathf.Clamp(health / maxHealth, 0, maxHealth));
    }
  }

  public void TakeDamage(float damage, GameObject attacker)
  {
    float actualDamage = damage * damageReduction;
    health -= actualDamage;
    Debug.Log(gameObject.name + " took " + actualDamage + " damage!");
    if (healthBarRenderer) healthBarRenderer.material.SetFloat("_Point", Mathf.Clamp(health / maxHealth, 0, maxHealth));

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
