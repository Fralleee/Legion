using UnityEngine;

public class Builder : MonoBehaviour
{
  Building buildingInstance;
  public void ActivateBuilding(UnitBuilding building)
  {
    GameObject buildingGo = Instantiate(building.building);
    buildingInstance = buildingGo.GetComponent<Building>();
    buildingInstance.SetUnit(building.unit);
    buildingInstance.Activate();
    buildingInstance.GetComponent<Building>().MoveBuilding(transform);
  }

  void Update()
  {
    if (buildingInstance)
    {
      if (Input.GetMouseButton(0)) Build();
      if (Input.GetMouseButton(1)) Cancel();
    }
  }

  public void Build()
  {
    buildingInstance.SetBuilding();
    buildingInstance = null;
  }

  public void Cancel()
  {
    Destroy(buildingInstance.gameObject);
  }
}
