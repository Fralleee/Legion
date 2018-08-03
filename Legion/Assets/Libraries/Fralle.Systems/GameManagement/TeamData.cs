using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
  Blue,
  Orange
}

[CreateAssetMenu(menuName = "Data/Team Data")]
public class TeamData : ScriptableObject
{
  public Team team;
  public int teamLayer;
  public int enemyLayer;
  public GameObject objective;

  void OnEnable() { objective = null; }

  public void MatchStart()
  {
    if (team == Team.Blue)
    {
      teamLayer = LayerMask.NameToLayer("Team Blue");
      enemyLayer = LayerMask.NameToLayer("Team Orange");
      objective = GameObject.Find("Orange Golem");
    }
    else
    {
      teamLayer = LayerMask.NameToLayer("Team Orange");
      enemyLayer = LayerMask.NameToLayer("Team Blue");
      objective = GameObject.Find("Blue Golem");
    }
  }

}
