using UnityEngine;

public class ToggleUI : MonoBehaviour
{
  [SerializeField] KeyCode key;
  bool displayItems;

  void Update()
  {
    if (Input.GetKeyDown(key)) Toggle();
  }

  public void Toggle()
  {
    displayItems = !displayItems;
    foreach (Transform t in transform) t.gameObject.SetActive(displayItems);
  }
}
