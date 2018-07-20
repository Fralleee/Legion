using UnityEngine;

public class Builder : BlockerBehaviour
{
  public ActiveBuilding activeBuilding;
  [HideInInspector] public bool isBuilding;

  [SerializeField] float castTime = 5.5f;

  [SerializeField] StringRangeVariable progress;

  [SerializeField] BoolVariable toggleBuildButton;

  [SerializeField] FloatVariable Gold;
  [SerializeField] FloatVariable Wood;

  [SerializeField] BuildingList availableBuildings;
  [SerializeField] ActiveBuildingList activeBuildings;

  [SerializeField] GameData gameData;

  Vector3 location;



  void Update()
  {
    if (!gameData.isPreparation)
    {
      toggleBuildButton.currentValue = false;
      InterruptBuilding();
      return;
    }
    ContinueBuilding();
  }

  public void StartBuilding()
  {
    if (gameData.isPreparation && !isBlocked && activeBuilding.CanBuild)
    {
      progress.text = "BUILDING!";
      progress.minValue = 0f;
      progress.maxValue = castTime;
      progress.value = 0f;
      isBuilding = true;
      activeBuilding.LockPosition();
      ApplyBlocker();
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
        RemoveBlocker();
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
      RemoveBlocker();
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
      RemoveBlocker();
      isBuilding = false;
    }
  }

  public bool isBlocked
  {
    get { return blockerList.blockers.Exists(x => x.Abilities && x != blocker); }
  }

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
