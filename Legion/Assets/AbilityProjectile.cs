using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityProjectile : MonoBehaviour
{
  public Ability ability;
  public List<AbilityEffect> effects;
  void Start()
  {
    GetComponent<Rigidbody>().AddForce(transform.forward * 10f, ForceMode.Impulse);
  }

  public void ApplyEffects(GameObject target)
  {
    Debug.Log("Applying effects to " + target.name);
    foreach (AbilityEffect effect in effects)
    {
      effect.Affect(ability, target);
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    Debug.Log("Collision with: " + collision.gameObject.name);
    ApplyEffects(collision.gameObject);
    Destroy(gameObject);
  }
}
