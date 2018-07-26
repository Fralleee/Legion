using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticsController : MonoBehaviour
{
  public TeamData teamData;
  public TargetStats targetStats;
  //public ActionStats actionStats;
  //public DefensiveStats defensiveStats;
  public Attributes attributes;

  void Start()
  {
    Invoke("DelayedStart", 0.25f);
  }

  // This is required when testing, however in an actual game
  // there should be no need to delay since the game manager has already set up team data.
  void DelayedStart()
  {
    gameObject.layer = teamData.teamLayer;
    targetStats.mainObjective = teamData.objective;
  }

  public void ClearTarget()
  {
    targetStats.currentTarget = null;
  }

  public void SetTarget(GameObject target)
  {
    if (target)
    {
      Debug.Log("New Target: " + target.gameObject.name);
      targetStats.currentTarget = target;
    }
    else ClearTarget();
  }

  public void SetStoppingDistance(float distance)
  {
    targetStats.stoppingDistance = distance;
  }

  public GameObject movementTarget { get { return targetStats.currentTarget ? targetStats.currentTarget : targetStats.mainObjective; } }
  public GameObject actionTarget { get { return targetStats.currentTarget; } }
}
