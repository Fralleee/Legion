using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Building/Available Buildings List")]
public class BuildingList : ScriptableObject
{
  [SerializeField] new string name;
  [SerializeField] string description;
  public List<Placeable> buildings = new List<Placeable>();
}
