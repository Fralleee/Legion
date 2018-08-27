using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ButtonHotkeyEvent : UnityEvent<int> { }

public class ButtonHotkey : MonoBehaviour
{
  [SerializeField] KeyCode hotkey;  
  [SerializeField] ButtonHotkeyEvent OnClick;
  DemoAnimManager demoAnimManager;

  void Start()
  {
    demoAnimManager = GetComponentInParent<DemoAnimManager>();
  }

  void LateUpdate()
  {
    if (demoAnimManager.isOn && Input.GetKeyDown(hotkey))
    {
      OnClick.Invoke(0);
    }
  }
}
