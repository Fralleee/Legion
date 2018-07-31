using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderInput : MonoBehaviour
{
  Builder builder;

  void Start()
  {
    builder = GetComponent<Builder>();  
  }

  void Update()
  {
    if(builder.activeBuilding)
    {
      if (Input.GetMouseButtonDown(0)) builder.StartBuilding();
      else if (Input.GetButtonDown("Cancel"))
      {
        if (builder.isBuilding) builder.CancelBuilding();
        else builder.activeBuilding.DeActivate();
      }
    }
  }
}
