using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Maybe this should be abstract or something
public class PointAbilityInstance : MonoBehaviour
{
  public void ApplyEffects(PointAbility ability)
  {
    LayerMask layerMask = 1 << ability.targetLayer;
    Collider[] colliders = Physics.OverlapSphere(transform.position, ability.aoeRange, layerMask);
    if (colliders.Length <= 0) return;
    foreach (Collider col in colliders)
    {
      foreach (AbilityEffect effect in ability.effects)
      {
        effect.Affect(ability, col.gameObject);
      }
    }
  }
}
