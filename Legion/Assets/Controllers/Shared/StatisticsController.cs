using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsController : MonoBehaviour
{
  public TeamData teamData;
  public Attributes attributes;

  AITargeter targeter;

  void Start()
  {
    targeter = GetComponent<AITargeter>();
    Invoke("DelayedStart", 0.25f);
  }

  // This is required when testing, however in an actual game
  // there should be no need to delay since the game manager has already set up team data.
  void DelayedStart()
  {
    gameObject.layer = teamData.teamLayer;
    if (targeter) targeter.SetObjective(teamData.objective);
  }

}
