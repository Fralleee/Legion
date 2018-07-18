   using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
  [SerializeField] GameObject unit;

  public void Initiate(Transform parent)
  {
    GetComponent<PlacementCollisionDetection>().SetDefaultMaterials();
    Destroy(GetComponent<PlacementCollisionDetection>());
    Destroy(GetComponent<SnapToGrid>());
    Destroy(GetComponent<Rigidbody>());
    transform.parent = parent;
  }

}
