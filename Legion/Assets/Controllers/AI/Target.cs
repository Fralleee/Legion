using UnityEngine;

public class Target
{
  public Transform transform;
  public string name;
  public float width = 0.5f;

  
  public Target(Transform t)
  {
    transform = t;
    width = t.GetComponent<Collider>().bounds.size.x / 2;
    name = t.name;
  }
}
