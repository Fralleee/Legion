using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementCollisionDetection : MonoBehaviour
{
  Renderer[] renderers;
  Material successMaterial;
  Material errorMaterial;

  List<Material> defaultMaterials = new List<Material>();
  List<int> triggerList = new List<int>();
  List<int> blockingLayers = new List<int>();

  bool allowedPosition;
  bool allowedTerrain;
  public bool allowedPlacement
  {
    get
    {
      return triggerList.Count == 0;
    }
  }

  void Start()
  {
    blockingLayers.Add(LayerMask.NameToLayer("Building"));
    blockingLayers.Add(LayerMask.NameToLayer("Buildable"));
    successMaterial = (Material)Resources.Load("Materials/SuccessMaterial");
    errorMaterial = (Material)Resources.Load("Materials/ErrorMaterial");
    renderers = GetComponentsInChildren<Renderer>();
    foreach (Renderer r in renderers) defaultMaterials.Add(r.material);
    SetMaterial();
  }

  void OnTriggerEnter(Collider other)
  {
    if (blockingLayers.Contains(other.gameObject.layer)) triggerList.Add(other.gameObject.layer);
    SetMaterial();
  }

  void OnTriggerExit(Collider other)
  {
    if (blockingLayers.Contains(other.gameObject.layer)) triggerList.Remove(other.gameObject.layer);
    SetMaterial();
  }

  void SetMaterial()
  {
    foreach (Renderer r in renderers) r.material = allowedPlacement ? successMaterial : errorMaterial;
  }

  public void SetDefaultMaterials()
  {
    for (int i = 0; i < renderers.Length; i++) renderers[i].material = defaultMaterials[i];
  }

}
