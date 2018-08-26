using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStoreUnit : MonoBehaviour
{
  DemoAnimManager demoAnimManager;
  PanelHandler panelHandler;
  Builder builder;
  public UnitBuilding unit;
  public KeyCode keyCode;

  void Start()
  {
    demoAnimManager = GetComponentInParent<DemoAnimManager>();
    panelHandler = GetComponentInParent<PanelHandler>();
    builder = GetComponentInParent<Builder>();
  }

  void Update()
  {
    if ((Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(keyCode)) && panelHandler.currentPanelIndex == 0)
    {
      OnClick();
    }
  }

  public void OnClick()
  {
    demoAnimManager.AnimatePanel();
    builder.ActivateBuilding(unit);
  }
}
