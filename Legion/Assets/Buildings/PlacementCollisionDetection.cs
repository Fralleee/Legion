using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCollisionDetection : MonoBehaviour
{
  [SerializeField] List<Renderer> renderers = new List<Renderer>();
  [SerializeField] Material successMaterial;
  [SerializeField] Material errorMaterial;

  List<Material> defaultMaterials = new List<Material>();
  List<int> triggerList = new List<int>();

  public bool allowedPosition = true;
  public bool allowedTerrain = true;
  public bool allowedPlacement = true;

  void Start()
  {
    foreach (Renderer r in renderers) defaultMaterials.Add(r.material);
    SetMaterial();
  }

  void OnTriggerEnter(Collider other)
  {
    triggerList.Add(other.gameObject.layer);
    Debug.Log("OnTriggerEnter: " + other.gameObject);
    allowedPosition = !triggerList.Contains(LayerMask.NameToLayer("Placeable"));
    allowedTerrain = triggerList.Contains(LayerMask.NameToLayer("Placeable Terrain"));

    Debug.Log("Correct layer: " + LayerMask.NameToLayer("Placeable Terrain"));
    Debug.Log("Layer in List: " + triggerList[0]);

    allowedPlacement = allowedPosition && allowedTerrain;
    SetMaterial();
  }

  void OnTriggerExit(Collider other)
  {
    Debug.Log("OnTriggerExit: " + other.gameObject);
    triggerList.Remove(other.gameObject.layer);
    allowedPosition = !triggerList.Contains(LayerMask.NameToLayer("Placeable"));
    allowedTerrain = triggerList.Contains(LayerMask.NameToLayer("Placeable Terrain"));
    allowedPlacement = allowedPosition && allowedTerrain;
    SetMaterial();
  }

  void SetMaterial()
  {
    foreach (Renderer r in renderers) r.material = allowedPlacement ? successMaterial : errorMaterial;
  }

  public void SetDefaultMaterials()
  {
    for (int i = 0; i < renderers.Count; i++) renderers[i].material = defaultMaterials[i];
  }

}
