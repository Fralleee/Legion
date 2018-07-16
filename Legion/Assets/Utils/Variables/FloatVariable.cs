using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
  public float defaultValue;

  [HideInInspector]
  public float currentValue;

  void OnEnable() { currentValue = defaultValue; }

}