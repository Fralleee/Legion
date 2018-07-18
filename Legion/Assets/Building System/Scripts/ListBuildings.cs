using UnityEngine;

public class ListBuildings : MonoBehaviour
{
  [SerializeField] ActiveBuilding currentPlaceable;
  [SerializeField] GameEventArgs onBuildingSelect;
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

  void Update()
  {
    if (Input.GetButtonDown("Building1")) SelectBuilding(0);
    else if (Input.GetButtonDown("Building2")) SelectBuilding(1);
    else if (Input.GetButtonDown("Building3")) SelectBuilding(2);
  }

  void SelectBuilding(int index)
  {
    currentPlaceable.placeable = buildingList.buildings[index];
    currentPlaceable.placeable.Initiate(GameObject.Find("Player").transform);
    onBuildingSelect.Raise(null);
  }
}
