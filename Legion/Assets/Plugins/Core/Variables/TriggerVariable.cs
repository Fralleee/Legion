using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Trigger")]
public class TriggerVariable : ScriptableObject
{
  public bool defaultValue;
  bool _currentValue;
  public bool currentValue
  {
    get { return _currentValue; }
    set
    {
      _currentValue = value;
      OnChange(this);
    }
  }
  public event Action<TriggerVariable> OnChange = delegate { };
  void OnEnable() { currentValue = defaultValue; }
  public bool Trigger()
  {
    if (currentValue)
    {
      currentValue = false;
      return true;
    }
    return false;
  }
}
