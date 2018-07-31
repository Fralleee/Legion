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
    Instantiate(unitPrefab, transform.position, transform.rotation);
  }

  public void Reset()
  {
    buildingUnitGraphics.SetActive(true);
  }
}
