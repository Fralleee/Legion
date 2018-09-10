using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnityEngine;

[CreateAssetMenu(fileName = "Keybindings", menuName = "Input/Keybindings")]
public class Keybindings : ScriptableObject
{
  [Header("Movement")]
  public KeyCode Forward, Backward, Left, Right, Jump;

  [Header("Abilities")]
  public KeyCode Ultimate, MainAttack, SecondaryAttack, Ability1, Ability2, Ability3, Ability4;

  [Header("RolePlaying")]
  public KeyCode Interact, Taunt, Dance;

  [Header("Menus")]
  public KeyCode OpenBuildMenu;

  Dictionary<string, KeyCode> actions;

  void OnEnable()
  {
    PropertyInfo[] properties = typeof(Keybindings).GetProperties().Where(x => x.GetType() == typeof(KeyCode)).ToArray();
    foreach (PropertyInfo property in properties)
    {
      actions.Add(property.Name, (KeyCode)property.GetConstantValue());
    }
  }

  public bool KeyDown(string key)
  {
    return Input.GetKeyDown(actions[key]);
  }
  public bool Key(string key)
  {
    return Input.GetKey(actions[key]);
  }
  public bool KeyUp(string key)
  {
    return Input.GetKeyUp(actions[key]);
  }
}

