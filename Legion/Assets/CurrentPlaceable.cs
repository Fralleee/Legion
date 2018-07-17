using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CurrentPlaceable : ScriptableObject
{
  public Placeable placeable;
  public void DeActivate() { placeable = null; }
}
