using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Direction")]
public class DirectionAbility : Ability
{
  public GameObject prefab;
  public override void Cast(bool selfCast = false)
  {
    base.Cast(selfCast);
    if (owner) owner.DirectionCast(this);
    else Debug.LogWarning("No owner on Ability: " + name);
  }
}
