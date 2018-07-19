using UnityEngine;
using Fralle;

public class SnapToGrid : MonoBehaviour
{
  [HideInInspector] public Transform parent;
  float factor = 1f;

  void Update()
  {
    float camXRot = Camera.main.transform.eulerAngles.x;
    int zPosition = camXRot > 30 ? 2 : camXRot > 20 ? 3 : camXRot > 10 ? 4 : 5;
    Vector3 position = new Vector3(parent.position.x, 0, parent.position.z) + parent.forward * zPosition;    
    transform.position = position.SnapToGrid(factor);
  }
}
