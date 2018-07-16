using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Placeable : ScriptableObject
{
  [SerializeField] float cost;
  [SerializeField] GameObject prefab;  
  GameObject instance;

  public void Initiate(Transform parent)
  {
    instance = Instantiate(prefab, new Vector3(parent.position.x, 0, parent.position.z) + parent.transform.forward * 2, Quaternion.Euler(0,0,0));
    instance.GetComponent<SnapToGrid>().parent = parent;
  }

  public void Cancel()
  {
    if(instance != null) Destroy(instance);
  }

  public bool CanBuild()
  {
    return instance.GetComponent<PlacementCollisionDetection>().allowedPlacement;
  }

  public void Build()
  {
    instance.GetComponent<Building>().Initiate();
    instance = null;
  }

}
