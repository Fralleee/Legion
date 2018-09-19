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
      float yPos = 0f;
      DamageController damageController = target.GetComponent<DamageController>();
      if (!damageController) return;
      switch (instantiationSettings.InstantiationPosition)
      {
        case TargetInstantiationPosition.TargetFeet: yPos = 0f; break;
        case TargetInstantiationPosition.TargetCenter: yPos = damageController.model.bounds.center.y; break;
        case TargetInstantiationPosition.TargetHead: yPos = damageController.model.bounds.max.y; break;
        default: break;
      }
      ParticleSystem onHit = followTarget
        ? Instantiate(onHitEffect, target.transform.position.With(y: yPos), Quaternion.identity, target.transform)
        : Instantiate(onHitEffect, target.transform.position.With(y: yPos), Quaternion.identity);
      if (instantiationSettings.useLocalScale) onHit.transform.localScale = target.transform.localScale;
      if (!constantEffect) Destroy(onHit.gameObject, onHit.main.duration + onHit.main.startLifetime.constantMax);
    }
    else Debug.LogWarning("No OnHitEffect for Effect: " + name);
  }
  public virtual void Affect(Ability ability, GameObject target, Vector3 direction) { Affect(ability, target); }
}
