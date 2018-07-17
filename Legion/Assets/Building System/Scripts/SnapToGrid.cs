using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
  [HideInInspector]
  public Transform parent;
  Vector3 gridPosition;
  float factor = 1f;

  void Update()
  {
    Vector3 position = new Vector3(parent.position.x, 0, parent.position.z) + parent.forward * 2;
    gridPosition = new Vector3(Mathf.Round(position.x / factor) * factor, 0, Mathf.Round(position.z / factor) * factor);
    transform.position = gridPosition;
  }
}
