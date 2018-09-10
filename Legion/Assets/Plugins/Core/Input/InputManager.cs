using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  public static InputManager instance;
  public Keybindings keybindings;

  void Awake()
  {
    if (instance == null) instance = this;
    else if (instance != this) Destroy(this);
    DontDestroyOnLoad(this);
  }

  public bool KeyDown(string key)
  {
    return keybindings.KeyDown(key);
  }
  public bool Key(string key)
  {
    return keybindings.Key(key);
  }
  public bool KeyUp(string key)
  {
    return keybindings.KeyUp(key);
  }

}

