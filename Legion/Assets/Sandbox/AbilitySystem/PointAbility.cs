using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Point")]
public class PointAbility : Ability
{
  public PointInstantiationSettings instantiationSettings;
  public GameObject prefab;
  public float aoeRange = 5f;
  public override void Cast(bool selfCast = false)
  {
    if(!transferEffectsToPrefab)
      Debug.LogWarning("Dont forget about transferEffectsToPrefab");
    if (owner)
      owner.StartCoroutine(owner.PointCast(this));
    else
      Debug.LogWarning("No owner on Ability: " + name);
  }
}
