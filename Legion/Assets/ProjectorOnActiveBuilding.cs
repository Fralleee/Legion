using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectorOnActiveBuilding : MonoBehaviour
{
  [SerializeField] ActiveBuilding activeBuilding;
  Projector projector;

  void Start()
  {
    projector = GetComponent<Projector>();
  }

  void Update()
  {
    projector.enabled = activeBuilding.instance != null;
  }
}
