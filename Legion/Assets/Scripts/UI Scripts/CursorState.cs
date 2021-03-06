﻿using UnityEngine;

public class CursorState : MonoBehaviour
{
  [SerializeField] BoolVariable isMenuOpen;    
  CursorLockMode defaultValue = CursorLockMode.Locked;

  void Awake()
  {
    isMenuOpen.OnChange += MenuLockState;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      defaultValue = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
      Cursor.lockState = defaultValue;
    }

    //if(isMenuOpen.currentValue) Cursor.lockState = CursorLockMode.None;
    //else Cursor.lockState = defaultValue;
  }

  void MenuLockState(bool value)
  {
    Cursor.lockState = value ? CursorLockMode.None : defaultValue;
  }
}
