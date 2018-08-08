using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityTargeter : MonoBehaviour, ITargeter
{
  protected const float TARGET_SCAN_RATE = 0.5f;
  protected const int MIN_AGGRO_RANGE = 15;
  public Target CurrentTarget { get; set; }
  public Target MainTarget { get; set; }
  public Target Objective { get; set; }
  [HideInInspector] public float lastScan { get; set; }
  [HideInInspector] public float lastLosCheck { get; set; }
  [HideInInspector] public bool lastLosResult { get; set; }
  [HideInInspector] public float losCheckRate = 0.25f;
  public bool PerformLoSCheck { get { return Time.time > lastLosCheck; } }

}
