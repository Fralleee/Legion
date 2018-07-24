using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValidateAbilityWithRules : BlockerBehaviour
{
  ImageFillColor imageSettings;

  void Start()
  {
    imageSettings = GetComponentInChildren<ImageFillColor>();
  }

  public void Validate()
  {
    if(imageSettings)
    {
      if (blockerList.blockers.Exists(x => x.Abilities)) imageSettings.readyColor = Color.gray;
      else imageSettings.readyColor = Color.white;
    }
  }
}
