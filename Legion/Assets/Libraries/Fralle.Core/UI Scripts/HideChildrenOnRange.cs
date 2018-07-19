using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fralle;

public class HideChildrenOnRange : MonoBehaviour
{
  [SerializeField] RangeVariable range;
  void Update()
  {
    if (range.value > range.minValue) transform.EnableChildren();
    else transform.DisableChildren();
  }
}
