using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBuildMenu : MonoBehaviour
{
  bool displayItems = false;

  void Update()
  {
    if (Input.GetButtonDown("Build")) Toggle();
  }

  public void Toggle()
  {
    displayItems = !displayItems;
    foreach (Transform t in transform) t.gameObject.SetActive(displayItems);
  }
}
