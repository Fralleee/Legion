﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActionEffect : ScriptableObject
{
  public virtual void Affect(GameObject target) { }
  public virtual void Affect(GameObject target, GameObject caster) { }
  public virtual void Affect(GameObject target, GameObject caster, float amount) { }
}
