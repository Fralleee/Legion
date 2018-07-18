using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building/Active Buildings List")]
public class ActiveBuildingList : ScriptableObject
{
  public int Count { get { return buildings.Count; } }  
  public List<GameObject> buildings = new List<GameObject>();

  public void Add(GameObject thing)
  {
    if (!buildings.Contains(thing)) buildings.Add(thing);
  }

  public void Remove(GameObject thing)
  {
    if (buildings.Contains(thing)) buildings.Remove(thing);
  }

  void OnEnable() { buildings = new List<GameObject>(); }

}
