using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect : ScriptableObject
{
  public ParticleSystem onHitEffect;
  public virtual void Affect(Ability ability, GameObject target)
  {
    if (onHitEffect)
    {
      ParticleSystem onHit = Instantiate(onHitEffect, target.transform.position.WithY(target.transform.localScale.y), Quaternion.identity);
      onHit.transform.localScale = target.transform.localScale;
      Destroy(onHit.gameObject, onHit.main.startLifetime.constant);
    }
    else Debug.LogWarning("No OnHitEffect for Effect: " + name);
  }
}
