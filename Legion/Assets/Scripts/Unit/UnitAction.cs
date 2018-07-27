using Fralle;
using System.Collections.Generic;
using UnityEngine;

public enum TargetType
{
  Hostile,
  Friendly,
  Self
}

public abstract class UnitAction : ScriptableObject
{
  [SerializeField] protected Blocker castTimeBlocker;
  [SerializeField] protected float castTime;
  [SerializeField] protected float performActionTime;

  [SerializeField] protected List<ActionEffect> actionEffects;
  public TargetType targetType;
  public float cooldown = 1f;
  public bool requireLineOfSight;
  // These are not required if TargetType is self
  // use an editor script for this
  public float range;

  [Range(15, 100)]
  public float scanRange = 15f;

  protected float tryPerformBuffer = 0.25f;

  protected GameObject caster;
  protected StatisticsController casterStats;
  protected BlockerController casterBlockerController;
  protected float lastCast;
  protected int environmentLayer;

  void OnEnable()
  {
    lastCast = 0f;
    performActionTime = 0f;
    environmentLayer = LayerMask.NameToLayer("Environment");
    scanRange = scanRange < range ? range : scanRange;
  }

  public bool onCooldown { get { return Time.time < lastCast; } }
  public bool readyToPerform { get { return Time.time > performActionTime; } }

  public virtual void SetupAction(GameObject casterObject)
  {
    caster = casterObject;
    casterStats = caster.GetComponent<StatisticsController>();
    casterBlockerController = caster.GetComponent<BlockerController>();
  }

  public virtual void StartPerform()
  {
    performActionTime = Time.time + castTime;
    if (castTimeBlocker) casterBlockerController.AddBlocker(castTimeBlocker);
  }

  public virtual void Perform(GameObject target)
  {
    lastCast = Time.time + cooldown;
    if (castTimeBlocker) casterBlockerController.RemoveBlocker(castTimeBlocker);
  }

  public virtual bool TryPerform(GameObject target)
  {
    if (requireLineOfSight)
    {
      if (caster.GetComponent<AITargeter>().hasLineOfSight) return true;
      lastCast = Time.time + tryPerformBuffer;
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
