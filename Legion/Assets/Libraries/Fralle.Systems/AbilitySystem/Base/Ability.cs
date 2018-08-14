using System.Collections.Generic;
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

  [Range(0.5f, 5)]
  public float RecoveryTime = 0.5f;
  [Space(10)]

  [Header("Ability Effects")]
  public CastAnimations CastAnimation = CastAnimations.DirectTrigger;
  public ParticleSystem castingEffect;
  public List<AbilityEffect> effects = new List<AbilityEffect>();

  [HideInInspector] protected float lastAction = 0;
  [HideInInspector] public float lastTargetScan = 0;
  [HideInInspector] public float lastLoSCheck = 0;
  [HideInInspector] public float losScanRate = 0.25f;


  public bool IsReady { get { return Time.time > lastAction; } }

  public virtual void Setup(GameObject caster)
  {
    Caster = caster;
    lastAction = 0;
    lastLoSCheck = 0;
    lastTargetScan = 0;
  }

  public virtual void Cast(GameObject target) { lastAction = Time.time + Cooldown; }

  public GameObject FindTarget(AITargeter targeter)
  {
    Vector3 currentPosition = targeter.transform.position;
    if (targeter.MainTarget && IsMainAbility) return ValidateMainTarget(targeter);
    if (targetType == TargetType.SELF) return Caster;
    if ((Time.time < lastTargetScan + TargetScanRate)) return null;

    lastTargetScan = Time.time;
    int searchLayer = targetType == TargetType.FRIENDLY ? 1 << targeter.gameObject.layer : 1 << targeter.EnemyLayer;
    return TargetScanner.FindTarget(Caster.transform, AbilityRange, searchLayer, RequireLineOfSight, TargetPriority);
  }
  public GameObject ValidateMainTarget(AITargeter targeter)
  {
    if (RequireLineOfSight && Time.time > lastLoSCheck)
    {
      lastLoSCheck = Time.time + losScanRate;
      bool inLineOfSight = TargetScanner.LineOfSightLayer(targeter.MainTarget, targeter.transform, AbilityRange);
      if (inLineOfSight) return targeter.MainTarget;
    }
    else if (Vector3.Distance(targeter.MainTarget.transform.position, targeter.transform.position) < AbilityRange) return targeter.MainTarget;
    return null;
  }
}
