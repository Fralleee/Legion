using UnityEngine;

public class FixedRotation : MonoBehaviour
{
  Quaternion rotation;
  void Awake() { rotation = transform.rotation; }
  void LateUpdate() { transform.rotation = rotation; }
}
