using UnityEngine;

public class Builder : MonoBehaviour
{
  [Header("Builder Settings")]
  public ActiveBuilding activeBuilding;
  [HideInInspector] public bool isBuilding;

  [SerializeField] float castTime = 5.5f;

  [SerializeField] StringRangeVariable progress;

  [SerializeField] BoolVariable toggleBuildButton;

  [SerializeField] FloatVariable Gold;
  [SerializeField] FloatVariable Wood;

  [SerializeField] BuildingList availableBuildings;
  [SerializeField] ActiveBuildingList activeBuildings;

  //[SerializeField] GameData gameData;

  Vector3 location;

  [SerializeField] Blocker blocker;
  BlockerController blockerController;

  void Start()
  {
    blockerController = GetComponent<BlockerController>();
  }

  void Update()
  {
    if (isBlocked)
    {
      toggleBuildButton.currentValue = false;
      InterruptBuilding();
      return;
    }
    ContinueBuilding();
  }

  public void StartBuilding()
  {
    if (!isBlocked && activeBuilding.CanBuild)
    {
      progress.text = "BUILDING!";
      progress.minValue = 0f;
      progress.maxValue = castTime;
      progress.value = 0f;
      isBuilding = true;
      activeBuilding.LockPosition();
      blockerController.AddBlocker(blocker);
    }
  }

  public void ContinueBuilding()
  {
    if (isBuilding && !isBlocked)
    {
      progress.value += Time.deltaTime;
      if (progress.value >= progress.maxValue)
      {
        Gold.currentValue -= activeBuilding.building.gold;
        Wood.currentValue -= activeBuilding.building.wood;
        activeBuildings.Add(activeBuilding.instance);
        activeBuilding.Build(name);
        activeBuilding.DeActivate();
        progress.value = 0f;
        isBuilding = false;
        blockerController.RemoveBlocker(blocker);
      }
    }
  }

  public void InterruptBuilding()
  {
    if (isBuilding)
    {
      progress.value = 0f;
      activeBuilding.Cancel();
      activeBuilding.DeActivate();
      blockerController.RemoveBlocker(blocker);
      isBuilding = false;
    }
  }

  public void CancelBuilding()
  {
    if (isBuilding)
    {
      progress.value = 0f;
      activeBuilding.Cancel();
      activeBuilding.DeActivate();
      blockerController.RemoveBlocker(blocker);
      isBuilding = false;
    }
  }

  public bool isBlocked { get { return blockerController.ContainsBlocker(production: true); } }

  void OnTriggerStay(Collider other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("Placeable Terrain")) toggleBuildButton.currentValue = true;
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("Placeable Terrain")) toggleBuildButton.currentValue = false;
  }

  public void OnBuildingSelected()
  {
    activeBuilding.Activate();
  }

}
