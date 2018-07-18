using UnityEngine;

[CreateAssetMenu(menuName = "Building/Active Building")]
public class ActiveBuilding : ScriptableObject
{
  public Placeable placeable;
  Placeable defaultValue = null;
  void OnEnable() { placeable = defaultValue; }
  public GameObject instance
  {
    get { return placeable ? placeable.GetInstance() : null; }
  }
  public void Activate(Placeable p)
  {
    placeable = p;
    placeable.Initiate(GameObject.Find("Player").transform);
  }
  public void DeActivate()
  {
    if (placeable) placeable.Cancel();
    placeable = null;
  }
}
