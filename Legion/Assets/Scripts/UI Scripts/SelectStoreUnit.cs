using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStoreUnit : MonoBehaviour
{
  [SerializeField] BoolVariable isMenuOpen;

  public UnitBuilding unit;
  public KeyCode keyCode;

  DemoAnimManager demoAnimManager;
  Builder builder;
  PlayerStats playerStats;
  Button button;
  bool canAfford;

  void Start()
  {
    demoAnimManager = GetComponentInParent<DemoAnimManager>();
    builder = GetComponentInParent<Builder>();
    playerStats = GetComponentInParent<PlayerStats>();
    button = GetComponent<Button>();
  }

  void ValidateCost()
  {
    if (playerStats.Gold.currentValue < unit.goldCost) canAfford = false;
    else if (playerStats.Wood.currentValue < unit.woodCost) canAfford = false;
    else canAfford = true;
  }

  void Update()
  {
    ValidateCost();
    button.interactable = canAfford;
    if (isMenuOpen.currentValue && Input.GetKeyDown(keyCode)) OnClick();
  }

  public void OnClick()
  {
    if (!canAfford) return;
    demoAnimManager.AnimatePanel();
    builder.ActivateBuilding(unit);
  }
}
