﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RangeVariable : ScriptableObject
{
  public float minValue = 0f;
  public float maxValue = 1f;
  public float value = 0f;
}
