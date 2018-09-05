using UnityEngine;

public class FixedPosition : MonoBehaviour
{
  Vector3 position;
  void Awake() { position = transform.position; }
  void LateUpdate() { transform.position = position; }
}
