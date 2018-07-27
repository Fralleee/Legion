using Fralle;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
  Hostile,
  Friendly,
  Self
}

public abstract class Ability : ScriptableObject
{
  [SerializeField] protected Blocker castTimeBlocker;
  [SerializeField] protected float castTime;
  [SerializeField] protected float finishedCastTime;

  [SerializeField] protected List<AbilityEffect> abilityEffects;
  public TargetType targetType;
  public float cooldown = 1f;
  public bool requireLineOfSight;

  // These are not required if TargetType is self
  // use an editor script for this
  public float range;

  [Range(15, 100)]
  public float scanRange = 15f;

  protected float tryCastBufferTime = 0.25f;

  protected GameObject caster;
  protected StatisticsController casterStats;
  protected BlockerController casterBlockerController;
  protected float lastCast;
  protected int environmentLayer;

  void OnEnable()
  {
    lastCast = 0f;
    finishedCastTime = 0f;
    environmentLayer = LayerMask.NameToLayer("Environment");
    scanRange = scanRange < range ? range : scanRange;
  }

  public bool onCooldown { get { return Time.time < lastCast; } }
  public bool readyToCast { get { return Time.time > finishedCastTime; } }

  public virtual void SetupAbility(GameObject casterObject)
  {
    caster = casterObject;
    casterStats = caster.GetComponent<StatisticsController>();
    casterBlockerController = caster.GetComponent<BlockerController>();
  }

  public virtual void PrepareCast()
  {
    finishedCastTime = Time.time + castTime;
    if (castTimeBlocker) casterBlockerController.AddBlocker(castTimeBlocker);
  }

  public virtual void Perform(GameObject target)
  {
    lastCast = Time.time + cooldown;
    if (castTimeBlocker) casterBlockerController.RemoveBlocker(castTimeBlocker);
  }

  public virtual bool TryCast(GameObject target)
  {
    if (requireLineOfSight)
    {
      if (caster.GetComponent<AITargeter>().hasLineOfSight) return true;
      lastCast = Time.time + tryCastBufferTime;
      return false;
    }
    return true;
  }

  public virtual void Interrupt(GameObject caster)
  {
    lastCast = 0f;
    if (castTimeBlocker) casterBlockerController.RemoveBlocker(castTimeBlocker);
  }

}
