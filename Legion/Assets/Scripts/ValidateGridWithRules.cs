using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateGridWithRules : MonoBehaviour
{
  Projector projector;
  BlockerController blockerController;

  void Awake()
  {
    projector = GetComponent<Projector>();
    blockerController = GetComponent<BlockerController>();
  }

  public void Validate()
  {
    projector.enabled = blockerController.ContainsBlocker(production: true);
  }
}
