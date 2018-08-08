﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargeter : AbilityTargeter
{
  [Header("Look origin")]
  public Transform Eyes;

  [Header("Layer masks")]
  public LayerMask EnvironmentLayerMask;
  public LayerMask EnemyLayerMask;
  public int EnemyLayer;

  [Header("Floats")]
  public float LookRange = 15f;

  [Header("Target Information")]
  public string CurrentTargetString;
  public string MainTargetString;
  public string ObjectiveString;


  public void SetCurrentTarget(GameObject go)
  {
    if (!go) return;
    CurrentTarget = new Target(go);
  }
  public void SetMainTarget(GameObject go)
  {
    if (!go) return;
    Debug.Log("New MainTarget: " + go.name);
    MainTarget = new Target(go);
  }
  public void SetObjective(GameObject go)
  {
    if (!go) return;
    Debug.Log("New Objective: " + go.name);
    CurrentTarget = new Target(go);
    Objective = new Target(go);
  }
  public void SetAggroRange(int range) { LookRange = Mathf.Max(range, MIN_AGGRO_RANGE); }

  public bool FindHostiles()
  {
    if (Time.time > lastScan)
    {
      lastScan = Time.time + TARGET_SCAN_RATE;
      bool hasFound = TargetScanner.FindHostiles(this);
      return hasFound;
    }
    return false;
  }

  void Update()
  {
    CurrentTargetString = CurrentTarget ? CurrentTarget.name : "None";
    MainTargetString = MainTarget ? MainTarget.name : "None";
    ObjectiveString = Objective ? Objective.name : "None";
  }

}