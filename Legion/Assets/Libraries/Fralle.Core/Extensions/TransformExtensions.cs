using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fralle
{
  public static class TransformExtensions
  {
    public static void EnableChildren(this Transform transform)
    {
      foreach (Transform t in transform) t.gameObject.SetActive(true);
    }
    public static void DisableChildren(this Transform transform)
    {
      foreach (Transform t in transform) t.gameObject.SetActive(false);
    }
  }
}
