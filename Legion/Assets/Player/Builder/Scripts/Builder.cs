using UnityEngine;

public class Builder : MonoBehaviour
{
  [SerializeField] float castTime = 0.5f;
  [SerializeField] StringRangeVariable progress;
  [SerializeField] ActiveBuilding currentPlaceable;

  [SerializeField] BlockerList blockerList;
  [SerializeField] Blocker blocker;
  [SerializeField] BoolVariable toggleBuildButton;

  [SerializeField] FloatVariable Gold;
  [SerializeField] FloatVariable Wood;

  [SerializeField] ActiveBuildingList activeBuildings;
  Vector3 location;

  bool isBuilding;
  void Update()
  {
    if (currentPlaceable.placeable != null)
    {
      if (Input.GetMouseButtonDown(0) && !isBlocked && currentPlaceable.placeable.canBuild)
      {
        progress.text = "BUILDING!";
        progress.minValue = 0f;
        progress.maxValue = castTime;
        progress.value = 0f;
        isBuilding = true;
        currentPlaceable.placeable.LockPosition();
        ApplyBlocker();
      }
      else if (isBuilding && !isBlocked)
      {
        progress.value += Time.deltaTime;
        if (progress.value >= progress.maxValue)
        {
          Gold.currentValue -= currentPlaceable.placeable.gold;
          Wood.currentValue -= currentPlaceable.placeable.wood;
          activeBuildings.Add(currentPlaceable.instance);
          currentPlaceable.placeable.Build(name);
          currentPlaceable.DeActivate();
          progress.value = 0f;
          isBuilding = false;
          RemoveBlocker();
        }
      }
      else if (isBuilding && (Input.GetMouseButtonDown(1) || isBlocked))
      {
        progress.value = 0f;
        currentPlaceable.placeable.Cancel();
        currentPlaceable.DeActivate();
        isBuilding = false;
      }
    }

  }

  void ApplyBlocker()
  {
    if (!blockerList.blockers.Contains(blocker)) blockerList.blockers.Add(blocker);
  }

  void RemoveBlocker()
  {
    if (blockerList.blockers.Contains(blocker)) blockerList.blockers.Remove(blocker);
  }

  public bool isBlocked
  {
    get { return blockerList.blockers.Exists(x => x.Abilities && x != blocker); }
  }
  
  void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.layer == LayerMask.NameToLayer("Placeable Terrain")) toggleBuildButton.currentValue = true;
  }

  void OnTriggerExit(Collider other)
  {
    if (other.gameObject.layer == LayerMask.NameToLayer("Placeable Terrain")) toggleBuildButton.currentValue = false;
  }

}
