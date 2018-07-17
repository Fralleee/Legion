using UnityEngine;

public class ToggleUI : MonoBehaviour
{
  [SerializeField] KeyCode key;
  [SerializeField] BoolVariable show;
  bool displayItems = false;
  void Update()
  {
    if (Input.GetKeyDown(key)) Toggle();
    //foreach (Transform t in transform) t.gameObject.SetActive(show.currentValue);
  }

  public void Toggle()
  {
    //show.currentValue = !show.currentValue;
    displayItems = true;
    foreach (Transform t in transform) t.gameObject.SetActive(displayItems);
  }

}
