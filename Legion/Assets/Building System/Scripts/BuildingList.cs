using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class BuildingList : ScriptableObject
{
  [SerializeField] string name;
  [SerializeField] string description;
  public List<Placeable> buildings = new List<Placeable>();
}
