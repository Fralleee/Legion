using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Direction")]
public class DirectionAbility : Ability
{
  public DirectionInstantiationSettings instantiationSettings;
  public GameObject prefab;

  public override void Cast(bool selfCast = false)
  {
    if (owner)
      owner.StartCoroutine(owner.DirectionCast(this));
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
