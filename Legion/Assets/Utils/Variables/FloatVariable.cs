using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
  public float defaultValue;
  public float currentValue;

  void OnEnable() { currentValue = defaultValue; }

}