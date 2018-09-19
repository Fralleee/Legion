using UnityEngine;
using System.Collections;
using System.Linq;

public class CullAnimator : MonoBehaviour
{
  Camera mainCamera;
  GameObject[] gameObjects;
  [SerializeField] float animDistance;
  [SerializeField] float farDistance;

  void Start()
  {
    gameObjects = FindObjectsOfType<GameObject>().Where(x => x.GetComponent<MeshRenderer>()).ToArray();
    mainCamera = Camera.main;
  }

  void Update()
  {
    foreach (GameObject gameObj in gameObjects)
    {
      if (!gameObj) continue;
      float distance = farDistance - Vector3.Distance(mainCamera.transform.position, gameObj.transform.position);
      float anim = distance / animDistance;
      anim = Mathf.Clamp01(anim);
      MeshRenderer mr = gameObj.GetComponent<MeshRenderer>();
      if (mr != null) mr.material.SetFloat("_Cull", anim);
    }
  }
}
