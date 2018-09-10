using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Variables/Bool")]
public class BoolVariable : ScriptableObject
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
  public event Action<bool> OnChange = delegate { };
  void OnEnable() { currentValue = defaultValue; }
}
