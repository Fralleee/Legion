using UnityEngine;

public class Spawner : MonoBehaviour
{
  [SerializeField] GameObject buildingUnitGraphics;
  [SerializeField] GameObject unitPrefab;

  Renderer graphicsRenderer;
  Material material;
  float time;
  bool regenerate;

  void Awake()
  {
    graphicsRenderer = buildingUnitGraphics.GetComponentInChildren<Renderer>();
    graphicsRenderer.material.shader = Shader.Find("graphs/Hologram");
  }

  public void SpawnUnit()
  {
    graphicsRenderer.material.SetFloat("Vector1_6BA813AB", 0f);
    Instantiate(unitPrefab, transform.position, transform.rotation);
  }

  public void StartRegeneration()
  {
    regenerate = true;
    time = -2f;
  }

  void Update()
  {
    if(regenerate)
    {
      time += Time.deltaTime * 0.1f;
      graphicsRenderer.material.SetFloat("Vector1_6BA813AB", Mathf.Lerp(0, 0.25f, time));
      if (time >= 1) regenerate = false;
    }
  }
}
