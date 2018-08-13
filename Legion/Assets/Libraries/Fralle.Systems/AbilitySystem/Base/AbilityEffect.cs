using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect : ScriptableObject
{
  public virtual void Affect(Ability ability, GameObject target) { }
}
