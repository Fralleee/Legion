using System.Collections.Generic;
using UnityEngine;
using Fralle;

[CreateAssetMenu(menuName = "Building/Active Buildings List")]
public class ActiveBuildingList : ScriptableObject
{
  public int Count { get { return buildings.Count; } }  
  public List<GameObject> buildings = new List<GameObject>();

  public void Add(GameObject building)
  {
    buildings.AddIfUnique(building);
  }

  public void Remove(GameObject building)
  {
    buildings.RemoveIfExists(building);
  }

  void OnEnable() { buildings = new List<GameObject>(); }

}
