using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITargeter : MonoBehaviour
{
  const float TARGET_SCAN_RATE = 0.5f;
  const int MIN_AGGRO_RANGE = 15;

  [Header("Look origin")]
  public Transform Eyes;

  [Header("Layer masks")]
  public LayerMask EnvironmentLayerMask;
  public LayerMask EnemyLayerMask;
  public int EnemyLayer;

  [Header("Floats")]
  public float LookRange = 15f;
  public float TargetWidth = 0.5f;
  float lastScan;

  [Header("Target Information")]
  public string CurrentTargetString;
  public string MainTargetString;
  public string ObjectiveString;
  public Target CurrentTarget;
  public Target MainTarget;
  public Target Objective;

  [HideInInspector] public float losCheckRate = 0.25f;
  [HideInInspector] public float lastLosCheck;
  [HideInInspector] public bool lastLosResult;
  public bool PerformLoSCheck { get { return Time.time > lastLosCheck; } }

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

  //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((CurrentTarget.transform.position - transform.position).normalized), Time.deltaTime * 4f);
}
