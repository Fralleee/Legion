using UnityEngine;

public abstract class Ability : ScriptableObject
{
  [Header("Ability Settings")]
  public string AbilityName = "Ability name";
  [HideInInspector] public bool IsMainAbility = false;
  public bool RequireLineOfSight = true;
  public TargetType targetType = TargetType.HOSTILE;
  public TargetPriority TargetPriority = TargetPriority.NEAREST;
  public GameObject Caster { get; set; }
  [Space(10)]

  [Header("Ability Stats")]
  public int AbilityRange = 2;
  public int MinAmount = 1;
  public int MaxAmount = 5;
  public float TargetScanRate = 0.5f;
  [Space(10)]

  [Header("Ability Cast Timers")]
  public float Cooldown = 2;
  public float WindupTime = 1;
  public float RecoveryTime = 0.25f;

  [HideInInspector] protected float lastAction = 0;
  [HideInInspector] public float lastTargetScan = 0;
  [HideInInspector] public float lastLoSCheck = 0;
  [HideInInspector] public float losScanRate = 0.25f;

  public CastAnimation Animation;

  public bool IsReady { get { return Time.time > lastAction; } }

  public virtual void Setup(GameObject caster)
  {
    Caster = caster;
    lastAction = 0;
    lastLoSCheck = 0;
    lastTargetScan = 0;
  }

  public virtual void Cast(GameObject target) { lastAction = Time.time + Cooldown; }

}
