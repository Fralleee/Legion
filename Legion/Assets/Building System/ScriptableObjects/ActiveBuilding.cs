using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ActiveBuilding : ScriptableObject
{
  public Placeable placeable;
  Placeable defaultValue = null;
  void OnEnable() { placeable = defaultValue;   }
  public void Activate(Placeable p) {
    placeable = p;
    placeable.Initiate(GameObject.Find("Player").transform);
  }
  public void DeActivate() {
    if(placeable) placeable.Cancel();
    placeable = null;
  }
}
