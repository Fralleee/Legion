using UnityEngine;

public class ToggleUI : MonoBehaviour
{
  [SerializeField] KeyCode key;
  void Update()
  {
    if (Input.GetKeyDown(key)) Toggle();
  }

  public void Toggle()
  {
    foreach (Transform t in transform) t.gameObject.SetActive(!t.gameObject.activeSelf);
  }
}
