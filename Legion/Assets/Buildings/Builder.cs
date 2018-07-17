using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
  public enum States
  {
    Default,
    Placing
  }
  States currentState = States.Default;

  [SerializeField] float castTime = 1f;
  [SerializeField] List<Placeable> buildings = new List<Placeable>();

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.E))
    {
      if (currentState == States.Default)
      {
        currentState = States.Placing;
        buildings[0].Initiate(transform);
      }
      else if (currentState == States.Placing)
      {
        if(buildings[0].CanBuild())
        {
          currentState = States.Default;
          buildings[0].Build();
        }
      }
    }
    if(Input.GetMouseButtonDown(1))
    {
      currentState = States.Default;
      buildings[0].Cancel();
    }
  }
}
