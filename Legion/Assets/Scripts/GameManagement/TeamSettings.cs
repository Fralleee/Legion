﻿using UnityEngine;

[CreateAssetMenu(menuName = "Game Management/Team Settings")]
public class TeamSettings : ScriptableObject
{
  public enum Team { Blue, Orange }
  public Team team;
  [HideInInspector] public int teamLayer;
  [HideInInspector] public int enemyLayer;
  public GameObject MainObjective;
  public void Setup()
  {
    teamLayer = LayerMask.NameToLayer(team == Team.Blue ? "Team Blue" : "Team Orange");
    enemyLayer = LayerMask.NameToLayer(team == Team.Blue ? "Team Orange" : "Team Blue");
    MainObjective = GameObject.Find(team == Team.Blue ? "Orange Golem" : "Blue Golem");
  }
  void OnEnable() { Setup(); }
}