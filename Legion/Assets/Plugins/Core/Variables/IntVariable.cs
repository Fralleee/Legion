using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Int")]
public class IntVariable : ScriptableObject
{
  public int defaultValue;
  public int currentValue;

  void OnEnable() { currentValue = defaultValue; }

}