using Fralle;
using UnityEngine;

public class Building : MonoBehaviour
{
  [SerializeField] TeamSettings teamSettings;
  [SerializeField] GameObject unit;

  Transform unitPlacement;
  GameObject unitInstance;

  void Start()
  {
    if (unit && !unitInstance && teamSettings) Activate(teamSettings);
    GameManager.SpawnUnits += Spawn;
  }
  public void Activate(TeamSettings teamSettingsParam)
  {
    teamSettings = teamSettingsParam;
    unitPlacement = transform.Find("UnitPlacement");
    Spawn();
  }

  void Spawn()
  {
    unitInstance = Instantiate(unit, unitPlacement.position, Quaternion.identity, transform);
    unitInstance.AddComponent<LockedPosition>();
    //unitInstance.GetComponent<AITargeter>().SetupTeam(teamSettings);
  }

  public void SetUnit(GameObject newUnit) { unit = newUnit; }
  public void MoveBuilding(Transform parent)
  {
    gameObject.AddComponent<SetBuilding>();
    transform.parent = parent;
  }
  public bool SetBuilding(Transform parent = null)
  {
    if (!GetComponent<PlacementCollisionDetection>().allowedPlacement) return false;
    Destroy(GetComponent<SetBuilding>());
    transform.position = transform.position.Flat();
    transform.parent = parent;
    return true;
  }

  void OnDestroy()
  {
    GameManager.SpawnUnits -= Spawn;
  }

}
