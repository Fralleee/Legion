using UnityEngine;

public class SetBuilding : MonoBehaviour
{
  PlacementCollisionDetection placementCollisionDetection;

  void Start()
  {
    gameObject.AddComponent<Rigidbody>();    
    gameObject.AddComponent<SnapToGrid>();
    placementCollisionDetection = gameObject.AddComponent<PlacementCollisionDetection>();
  }

  void OnDestroy()
  {
    placementCollisionDetection.SetDefaultMaterials();
    Destroy(GetComponent<PlacementCollisionDetection>());
    Destroy(GetComponent<Rigidbody>());
    Destroy(GetComponent<SnapToGrid>());
  }
}
