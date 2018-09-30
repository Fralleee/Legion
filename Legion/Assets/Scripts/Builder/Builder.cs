using UnityEngine;

public class Builder : MonoBehaviour
{
  [SerializeField] TeamSettings teamSettings;
  [SerializeField] Projector gridProjector;
  Building buildingInstance;
  UnitBuilding recentBuilding;
  bool canBuild;

  void Awake()
  {
    GameManager.EnableBuilding += EnableBuilding;
    GameManager.DisableBuilding += DisableBuilding;
  }

  void EnableBuilding() { canBuild = true; }
  void DisableBuilding()
  {
    canBuild = false;
    Cancel();
  }

  public void ActivateBuilding(UnitBuilding building)
  {
    if (!canBuild) return;
    gridProjector.enabled = true;
    if (buildingInstance) Destroy(buildingInstance.gameObject);
    recentBuilding = building;
    GameObject buildingGo = Instantiate(building.building);
    buildingInstance = buildingGo.GetComponent<Building>();
    buildingInstance.SetUnit(building.unit);
    buildingInstance.Activate(teamSettings);
    buildingInstance.GetComponent<Building>().MoveBuilding(transform);
  }

  void Update()
  {
    if (!buildingInstance || !canBuild) return;
    if (Input.GetMouseButtonDown(0))
    {
      if (Input.GetKey(KeyCode.LeftShift)) Build(true);
      else Build();
    }
    if (Input.GetMouseButtonDown(1)) Cancel();
  }

  public void Build(bool shouldReset = false)
  {
    if (!buildingInstance.SetBuilding()) return;
    gridProjector.enabled = false;
    buildingInstance = null;
    if (shouldReset) ActivateBuilding(recentBuilding);
  }

  public void Cancel()
  {
    gridProjector.enabled = false;
    if (buildingInstance) Destroy(buildingInstance.gameObject);
  }
}
