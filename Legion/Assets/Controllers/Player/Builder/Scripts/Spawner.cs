using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

  [SerializeField] GameObject unitPrefab;
  public void SpawnUnit()
  {
    Instantiate(unitPrefab, transform.position, transform.rotation);
  }

}
