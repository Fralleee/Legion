using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Building : MonoBehaviour
{
  [SerializeField] Team team;
  [SerializeField] GameObject unit;
  Transform unitPlacement;
  GameObject unitInstance;
  void Start()
  {
    if (unit && !unitInstance) Activate();
  }

  public void Activate()
  {
    unitPlacement = transform.Find("UnitPlacement");
    unitInstance = Instantiate(unit, unitPlacement.position, Quaternion.identity, transform);
    unitInstance.AddComponent<LockedPosition>();
    unitInstance.GetComponent<AITargeter>().SetObjective(team == Team.Blue ? GameObject.Find("Orange Golem") : GameObject.Find("Blue Golem"));
  }
  public void SetUnit(GameObject newUnit) { unit = newUnit; }
  public void MoveBuilding(Transform parent)
  {
    gameObject.AddComponent<SetBuilding>();
    transform.parent = parent;
  }
  public void SetBuilding(Transform parent = null)
  {
    Destroy(GetComponent<SetBuilding>());
    transform.position = transform.position.Flat();
    transform.parent = parent;
  }

}
