using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProjectile : MonoBehaviour
{
  public Ability ability;
  public List<AbilityEffect> effects;
  void Start()
  {
    GetComponent<Rigidbody>().AddForce(transform.forward * 25f, ForceMode.Impulse);
  }

  public void ApplyEffects(GameObject target)
  {
    foreach (AbilityEffect effect in effects)
    {
      effect.Affect(ability, target);
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    ApplyEffects(collision.gameObject);
    Destroy(gameObject);
  }
}
