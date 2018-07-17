using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideChildrenOnRange : MonoBehaviour
{
  [SerializeField] RangeVariable range;
  void Update()
  {
    if (range.value > range.minValue) ShowChildren();
    else HideChildren();
  }

  void HideChildren()
  {
    foreach (Transform t in transform) t.gameObject.SetActive(false);
  }

  void ShowChildren()
  {
    foreach (Transform t in transform) t.gameObject.SetActive(true);
  }
}
