using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
  [SerializeField] bool isPlacedFromStart;

  void Awake()
  {
    if (isPlacedFromStart) Initiate();
  }

  public void Initiate(Transform parent = null)
  {
    if (!isPlacedFromStart) GetComponent<PlacementCollisionDetection>().SetDefaultMaterials();
    Destroy(GetComponent<PlacementCollisionDetection>());
    Destroy(GetComponent<Rigidbody>());
    Destroy(GetComponent<SnapToGrid>());
    transform.parent = parent;
  }

}
