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
  protected GameObject caster;
  protected Stats casterStats;

  protected float lastCast;
  public TargetType targetType;

  // These are not required if TargetType is self
  public float range;
  public float scanRange = 10f;
  public float cooldown = 1f;

  [SerializeField] protected Blocker castTimeBlocker;
  [SerializeField] protected float castTime;
  [SerializeField] protected float readyTime;

  [SerializeField] protected bool requireLineOfSight;

  
  [SerializeField] protected List<ActionEffect> actionEffects;

  void OnEnable() {
    lastCast = 0f;
    readyTime = 0f;
  }

  public bool onCooldown { get { return Time.time < lastCast; } }
  public bool readyToPerform { get { return Time.time > readyTime; } }

  public virtual void SetupAction(GameObject casterObject) {
    caster = casterObject;
    casterStats = caster.GetComponent<Stats>();
  }

  public virtual void StartPerform()
  {
    readyTime = Time.time + castTime;
  }

  public virtual void Perform(GameObject target, GameObject caster) {
    lastCast = Time.time + cooldown;

    // Apply the blocker on the caster for the full duration

  }

  public virtual void Interrupt(GameObject caster)
  {
    lastCast = 0f; // Remove the cooldown
  }

}
