using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Target")]
public class TargetAbility : Ability
{
  public TargetInstantiationSettings instantiationSettings;
  public GameObject prefab;

  public override void Cast(bool selfCast = false)
  {
    if (owner)
      owner.StartCoroutine(owner.TargetCast(this, selfCast));
    else
      Debug.LogWarning("No owner on Ability: " + name);
  }

  public void ApplyEffects(GameObject target)
  {
    if (!transferEffectsToPrefab)
      foreach (AbilityEffect effect in effects)
        effect.Affect(this, target);
    else
      Debug.Log("Transfer effects to prefab: Not implemented");
  }

}
