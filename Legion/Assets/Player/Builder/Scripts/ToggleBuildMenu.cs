using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleBuildMenu : MonoBehaviour
{
  bool displayItems = false;
  [SerializeField] ActiveBuilding activeBuilding;
  [SerializeField] BoolVariable canShowBuildMenu;

  void Update()
  {
    if (displayItems && (Input.GetButtonDown("Build") || Input.GetButtonDown("Cancel"))) Toggle();
    else if (Input.GetButtonDown("Build") && canShowBuildMenu.currentValue) Toggle();
  }

  public void Toggle()
  {
    displayItems = !displayItems;
    foreach (Transform t in transform) t.gameObject.SetActive(displayItems);
    if (displayItems) activeBuilding.DeActivate();
  }
}
