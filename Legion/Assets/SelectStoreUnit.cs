using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectStoreUnit : MonoBehaviour
{
  DemoAnimManager demoAnimManager;
  Builder builder;
  public UnitBuilding unit;
  public KeyCode keyCode;

  void Start()
  {
    demoAnimManager = GetComponentInParent<DemoAnimManager>();
    builder = GetComponentInParent<Builder>();
  }

  void Update()
  {
    if (demoAnimManager.isOn && Input.GetKeyDown(keyCode)) OnClick();
  }

  public void OnClick()
  {
    demoAnimManager.AnimatePanel();
    builder.ActivateBuilding(unit);
  }
}
