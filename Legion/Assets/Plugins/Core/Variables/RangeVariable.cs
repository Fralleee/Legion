using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Range")]
public class RangeVariable : ScriptableObject
{
  public float minValue;
  public float maxValue = 1f;
  public float value;
  void OnEnable()
  {
    minValue = 0f;
    maxValue = 1f;
    value = 0f;
  }
}
