using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorState : MonoBehaviour
{
  [SerializeField] BoolVariable isMenuOpen;
  CursorLockMode defaultValue = CursorLockMode.Locked;
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      defaultValue = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
      Cursor.lockState = defaultValue;
    }

    if(isMenuOpen.currentValue) Cursor.lockState = CursorLockMode.None;
    else Cursor.lockState = defaultValue;
  }
}
