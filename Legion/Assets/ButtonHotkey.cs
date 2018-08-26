using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ButtonHotkeyEvent : UnityEvent<int> { }

public class ButtonHotkey : MonoBehaviour
{
  [SerializeField] KeyCode hotkey;
  [SerializeField] DemoAnimManager demoAnimManager;
  [SerializeField] PanelHandler panelHandler;
  [SerializeField] ButtonHotkeyEvent OnClick;

  void LateUpdate()
  {
    if (demoAnimManager.isOn && panelHandler.currentPanelIndex == -1 && Input.GetKeyDown(hotkey))
    {
      OnClick.Invoke(0);
    }
  }
}
