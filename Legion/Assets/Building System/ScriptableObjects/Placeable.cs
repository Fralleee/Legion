using UnityEngine;

[CreateAssetMenu(menuName = "Building/Placeable")]
public class Placeable : ScriptableObject
{
  public float gold;
  public float wood;
  [SerializeField] GameObject prefab;  
  GameObject instance;

  public bool canBuild
  {
    get
    {
      if (instance) return instance.GetComponent<PlacementCollisionDetection>().allowedPlacement;
      return false;
    }
  }

  public void Initiate(Transform parent)
  {
    instance = Instantiate(prefab, new Vector3(parent.position.x, 0, parent.position.z) + parent.transform.forward * 2, Quaternion.Euler(0,0,0));
    instance.GetComponent<SnapToGrid>().parent = parent;
  }

  public void Cancel()
  {
    if(instance != null) Destroy(instance);
  }


  public void Build(string name)
  {
    var parentBuildingRoot = GameObject.Find(name + "s buildings");
    if(!parentBuildingRoot) parentBuildingRoot = new GameObject(name + "s buildings");
    instance.GetComponent<Building>().Initiate(parentBuildingRoot.transform);
    instance = null;
  }

  public GameObject GetInstance()
  {
    return instance;
  }

}
