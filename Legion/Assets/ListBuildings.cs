using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListBuildings : MonoBehaviour
{

  [SerializeField] BuildingList buildingList;
  [SerializeField] GameObject prefab;

  void Start()
  {
    foreach (Placeable p in buildingList.buildings)
    {
      var instance = Instantiate(prefab, transform);
      instance.GetComponent<BuildingUI>().Initialize(p);
    }
  }

}
