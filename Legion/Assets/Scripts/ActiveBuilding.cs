using UnityEngine;

[CreateAssetMenu(menuName = "Building/Active Building")]
public class ActiveBuilding : ScriptableObject
{
  GameObject builder;
  [SerializeField] string builderName = "Player";
  public Placeable building;
  Placeable defaultValue = null;

  void OnEnable() {
    building = defaultValue;
    builder = GameObject.Find(builderName);
  }

  public GameObject instance
  {
    get { return building ? building.GetInstance() : null; }
  }

  public void Set(Placeable p)
  {
    building = p;
  }

  public void Activate()
  {
    building.Initiate(builder.transform);
  }

  public void DeActivate()
  {
    if (building) building.Cancel();
    building = null;
  }

  public void LockPosition()
  {
    building.LockPosition();
  }

  public void Build(string name)
  {
    building.Build(name);
  }

  public void Cancel()
  {
    building.Cancel();
  }

  public bool CanBuild
  {
    get
    {
      if (building && building.canBuild) return true;
      return false;
    }
  }

}
