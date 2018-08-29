using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnBool : MonoBehaviour {

  [SerializeField] BoolVariable value;
  [SerializeField] Behaviour[] behaviours;

	void Update ()
  {
    foreach (Behaviour behaviour in behaviours)
    {
      behaviour.enabled = !value.currentValue;
    }
	}
}
