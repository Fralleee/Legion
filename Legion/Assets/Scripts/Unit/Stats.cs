using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
  public TeamData teamData;
  public GameObject currentTarget; // This is here to have a centralized place to store target
  public GameObject mainObjective; // This is here to have a centralized place to store target
  public float stoppingDistance = 2f;

  void Start()
  {
    Invoke("DelayedStart", 0.25f);
  }
  void DelayedStart()
  {
    gameObject.layer = teamData.teamLayer;
    mainObjective = teamData.objective;
  }

  public void ClearTarget()
  {
    currentTarget = null;
  }

  public void SetNewTarget(GameObject target)
  {
    if (target)
    {
      Debug.Log("New Target: " + target.gameObject.name);
      currentTarget = target;
    }
    else ClearTarget();
  }

  public void SetStoppingDistance(float distance)
  {
    stoppingDistance = distance;
  }
}
