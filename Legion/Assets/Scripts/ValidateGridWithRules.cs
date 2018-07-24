using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateGridWithRules : BlockerBehaviour
{
  Projector projector;

  void Awake() { projector = GetComponent<Projector>(); }

  public void Validate()
  {
    projector.enabled = blockerList.blockers.Exists(x => !x.Production);
  }
}
