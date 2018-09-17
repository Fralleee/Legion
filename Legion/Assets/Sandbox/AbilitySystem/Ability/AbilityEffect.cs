using Fralle;
using UnityEngine;

public abstract class AbilityEffect : ScriptableObject
{
  public TargetInstantiationSettings instantiationSettings;
  public ParticleSystem onHitEffect;
  public bool constantEffect;
  public bool followTarget;
  public virtual void Affect(Ability ability, GameObject target)
  {
    if (onHitEffect)
    {
      ParticleSystem onHit = followTarget 
        ? Instantiate(onHitEffect, target.transform) 
        : Instantiate(onHitEffect, target.transform.position.With(y: target.transform.localScale.y), Quaternion.identity);
      onHit.transform.localScale = target.transform.localScale;
      if (!constantEffect)
        Destroy(onHit.gameObject, onHit.main.duration + onHit.main.startLifetime.constantMax);
    }
    else Debug.LogWarning("No OnHitEffect for Effect: " + name);
  }
}
