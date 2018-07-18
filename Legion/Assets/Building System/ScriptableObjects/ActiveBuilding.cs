using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActiveBuilding : ScriptableObject
{
  public Placeable placeable;
  Placeable defaultValue = null;
  void OnEnable() { placeable = defaultValue;   }
  public void DeActivate() { placeable = null; }
}
