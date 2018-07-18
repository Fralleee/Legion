using UnityEngine;

public class ListBuildingsUI : MonoBehaviour
{
  [SerializeField] ActiveBuilding currentPlaceable;
  [SerializeField] GameEventArgs onBuildingSelect;
  [SerializeField] BuildingList buildingList;
  [SerializeField] GameObject prefab;
  [SerializeField] FloatVariable Gold;
  [SerializeField] FloatVariable Wood;

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
    Placeable building = buildingList.buildings[index];
    if (building.gold > Gold.currentValue || building.wood > Wood.currentValue) return;
    currentPlaceable.DeActivate();
    currentPlaceable.Activate(buildingList.buildings[index]);
    onBuildingSelect.Raise(null);
  }

}
