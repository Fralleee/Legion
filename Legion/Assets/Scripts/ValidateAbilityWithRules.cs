using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateAbilityWithRules : MonoBehaviour
{
  ImageFillColor imageSettings;
  BlockerController blockerController;

  void Start()
  {
    imageSettings = GetComponentInChildren<ImageFillColor>();
    blockerController = GetComponent<BlockerController>();
  }

  public void Validate()
  {
    if (imageSettings)
    {
      if (blockerController.ContainsBlocker(actions: true)) imageSettings.readyColor = Color.gray;
      else imageSettings.readyColor = Color.white;
    }
  }
}
