using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BoolVariable : ScriptableObject
{
  public bool defaultValue;
  public bool currentValue;
  void OnEnable() { currentValue = defaultValue; }
}
