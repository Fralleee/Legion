using UnityEngine;

public class Target
{
  public GameObject gameObject;
  public Transform transform;
  public Vector3 position;
  public string name;
  public float Width = 0.5f;
  public static implicit operator bool(Target target) { return target != null && target.gameObject != null; }
  public static implicit operator Transform(Target target) { return target ? target.transform : null; }
  public static implicit operator GameObject(Target target) { return target ? target.gameObject : null; }
  public override string ToString() { return string.IsNullOrEmpty(name) ? name : null; }

  public Target(Transform t)
  {
    gameObject = t.gameObject;
    transform = t;
    position = t.position;
    Width = t.GetComponent<Collider>().bounds.size.x / 2;
    name = t.name;
  }

  public Target(GameObject go)
  {
    gameObject = go;
    transform = go.transform;
    position = go.transform.position;
    Width = go.GetComponent<Collider>().bounds.size.x / 2;
    name = go.name;
  }

}
