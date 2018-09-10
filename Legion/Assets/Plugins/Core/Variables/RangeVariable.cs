using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Range")]
public class RangeVariable : ScriptableObject
{
  public float minValue = 0f;
  public float maxValue = 1f;
  public float value = 0f;
  void OnEnable()
  {
    minValue = 0f;
    maxValue = 1f;
    value = 0f;
  }
}
