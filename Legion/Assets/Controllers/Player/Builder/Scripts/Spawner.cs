using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] GameObject buildingUnitGraphics;
  [SerializeField] GameObject unitPrefab;

  public void SpawnUnit()
  {
    buildingUnitGraphics.SetActive(false);
    GameObject instance = Instantiate(unitPrefab, transform.position, transform.rotation);
    instance.name = unitPrefab.name;
  }

  public void Reset()
  {
    buildingUnitGraphics.SetActive(true);
  }
}
