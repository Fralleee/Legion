using UnityEngine;

public class ToggleUI : MonoBehaviour
{
  [SerializeField] KeyCode key;
  [SerializeField] BoolVariable show;
  void Update()
  {
    if (Input.GetKeyDown(key)) show.currentValue = !show.currentValue;
    foreach (Transform t in transform) t.gameObject.SetActive(show.currentValue);
  }

}
