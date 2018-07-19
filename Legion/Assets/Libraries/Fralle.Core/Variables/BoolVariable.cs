using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject
{
  public bool defaultValue;
  public bool currentValue;
  void OnEnable() { currentValue = defaultValue; }
}
