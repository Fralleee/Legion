using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Point")]
public class PointAbility : Ability
{
  public GameObject prefab;
  public override void Cast(bool selfCast = false)
  {
    Debug.LogWarning("Dont forget about transferEffectsToPrefab");
    if (owner) owner.PointCast(this);
    else Debug.LogWarning("No owner on Ability: " + name);
  }
}
