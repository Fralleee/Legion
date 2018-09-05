using UnityEngine;
using Fralle;

public class AITargeter : MonoBehaviour, ITargeter
{
  const float TARGET_SCAN_RATE = 0.5f;
  const int MIN_AGGRO_RANGE = 15;

  public Target currentTarget { get; set; }
  public Target mainTarget { get; set; }
  public Target objective { get; set; }
  public bool PerformLoSCheck { get { return Time.time > lastLosCheck; } }
  [HideInInspector] public float lastScan { get; set; }
  [HideInInspector] public float lastLosCheck { get; set; }
  [HideInInspector] public bool lastLosResult { get; set; }
  [HideInInspector] public float losCheckRate = 0.25f;

  [Header("Layer masks")]
  public LayerMask EnvironmentLayerMask;
  public LayerMask EnemyLayerMask;
  public int EnemyLayer;

  [HideInInspector] public float LookRange = 15f;
  
  public void SetAggroRange(int range) { LookRange = Mathf.Max(range, MIN_AGGRO_RANGE); }
  public bool FindTarget(Ability ability)
  {
    if (Time.time > lastScan)
    {
      lastScan = Time.time + TARGET_SCAN_RATE;
      bool hasFound = TargetScanner.FindHostilesLinq(this);
      return hasFound;
    }
    return false;
  }
}
