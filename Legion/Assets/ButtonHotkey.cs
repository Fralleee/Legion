using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ButtonHotkeyEvent : UnityEvent<int> { }

public class ButtonHotkey : MonoBehaviour
{
  [SerializeField] bool requireCtrlKey = true;
  [SerializeField] KeyCode hotkey;
  [SerializeField] ButtonHotkeyEvent OnClick;
  [SerializeField] DemoAnimManager demoAnimManager;

  void Update()
  {
    if (demoAnimManager.isOn && (requireCtrlKey && Input.GetKey(KeyCode.LeftControl)) && Input.GetKeyDown(hotkey))
    {
      OnClick.Invoke(0);
    }
  }
}
