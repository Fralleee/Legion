using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : Transform
{
  public float width;
  public Target(Transform t)
  {
    Collider collider = t.GetComponent<Collider>();
    if (collider) width = collider.bounds.size.x / 2;
    else Debug.LogError("Collider is missing on " + t.name);
  }
}
