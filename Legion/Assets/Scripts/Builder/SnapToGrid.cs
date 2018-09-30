using UnityEngine;
using Fralle;

public class SnapToGrid : MonoBehaviour
{
  float factor = 1.5f;
  void Update()
  {
    if (!transform.parent) return;
    float camXRot = Camera.main.transform.eulerAngles.x;
    int zPosition = camXRot > 30 ? 2 : camXRot > 20 ? 3 : camXRot > 10 ? 4 : 5;
    Vector3 position = transform.parent.position.Flat() + transform.parent.forward * zPosition;
    transform.position = position.SnapToGrid(factor);
    transform.rotation = Quaternion.identity;
  }
}
