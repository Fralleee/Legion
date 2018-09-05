using UnityEngine;
using Fralle;

public class AITargeter : MonoBehaviour
{
  const float TARGET_SCAN_RATE = 0.5f;
  const int MIN_AGGRO_RANGE = 15;

  public Target CurrentTarget { get; set; }
  public Target MainTarget { get; set; }
  public Target Objective { get; set; }
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

  public void SetCurrentTarget(GameObject go)
  {
    if (!go) return;
    CurrentTarget = new Target(go);
  }
  public void SetMainTarget(GameObject go)
  {
    if (!go) return;
    MainTarget = new Target(go);
  }
  public void SetupTeam(TeamSettings teamSettings)
  {
    if (!teamSettings.MainObjective) Debug.LogWarning("No Objective in team settings");
    CurrentTarget = new Target(teamSettings.MainObjective);
    Objective = new Target(teamSettings.MainObjective);
    gameObject.layer = teamSettings.teamLayer;
    EnemyLayer = teamSettings.enemyLayer;
    EnemyLayerMask = 1 << teamSettings.enemyLayer;
    EnvironmentLayerMask = 1 << LayerMask.NameToLayer("Environment");
  }

  public void SetAggroRange(int range) { LookRange = Mathf.Max(range, MIN_AGGRO_RANGE); }
  public bool FindHostiles()
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
