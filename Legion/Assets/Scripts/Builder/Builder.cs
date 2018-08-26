using UnityEngine;

public class Builder : MonoBehaviour
{
  Building buildingInstance;
  UnitBuilding recentBuilding;
  public void ActivateBuilding(UnitBuilding building)
  {
    if(buildingInstance) Destroy(buildingInstance.gameObject);
    recentBuilding = building;
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
      if (Input.GetMouseButtonDown(0))
      {
        if (Input.GetKey(KeyCode.LeftShift)) Build(true);
        else Build();
      }
      if (Input.GetMouseButtonDown(1)) Cancel();
    }
  }

  public void Build(bool shouldReset = false)
  {    
    if(buildingInstance.SetBuilding())
    {
      buildingInstance = null;
      if (shouldReset) ActivateBuilding(recentBuilding);
    }
  }

  public void Cancel()
  {
    Destroy(buildingInstance.gameObject);
  }
}
