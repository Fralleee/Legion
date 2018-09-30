using System.Collections.Generic;
using UnityEngine;

public class AbilityProjectile : MonoBehaviour
{
  [HideInInspector] public Ability ability;
  [HideInInspector] public List<AbilityEffect> effects;
  [SerializeField] float force = 25f;
  [SerializeField] ForceMode forceMode = ForceMode.Force;
  [SerializeField] float delayedDestruction;
  new Rigidbody rigidbody;

  void Start()
  {
    rigidbody = GetComponent<Rigidbody>();
    rigidbody.AddForce(transform.forward * force, forceMode);
  }

  public void ApplyEffects(GameObject target)
  {
    foreach (AbilityEffect effect in effects)
    {
      effect.Affect(ability, target, rigidbody.velocity.normalized);
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    ApplyEffects(collision.gameObject);
    Destroy(gameObject, delayedDestruction);
  }
}
