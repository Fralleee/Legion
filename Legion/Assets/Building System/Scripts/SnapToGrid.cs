using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToGrid : MonoBehaviour
{
  [HideInInspector] public Transform parent;
  Vector3 gridPosition;
  float factor = 1f;

  void Update()
  {
    float camXRot = Camera.main.transform.eulerAngles.x;
    int zPosition = camXRot > 30 ? 2 : camXRot > 20 ? 3 : camXRot > 10 ? 4 : 5;
    Vector3 position = new Vector3(parent.position.x, 0, parent.position.z) + parent.forward * zPosition;
    gridPosition = new Vector3(Mathf.Round(position.x / factor) * factor, 0, Mathf.Round(position.z / factor) * factor);
    transform.position = gridPosition;
  }
}
