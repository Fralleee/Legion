using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderInput : MonoBehaviour
{
  Builder builder2;

  void Start()
  {
    builder2 = GetComponent<Builder>();  
  }

  void Update()
  {
    if(builder2.activeBuilding)
    {
      if (Input.GetMouseButtonDown(0)) builder2.StartBuilding();
      else if (builder2.isBuilding && Input.GetMouseButtonDown(1)) builder2.CancelBuilding();
    }
  }
}
