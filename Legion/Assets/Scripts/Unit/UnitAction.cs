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
  [SerializeField] protected bool requireLineOfSight;

  [SerializeField] protected float castTime = 0f;
  [SerializeField] protected float cooldown = 1f;
  [SerializeField] protected List<ActionEffect> actionEffects;

  void OnEnable() { lastCast = 0f; }

  public bool onCooldown { get { return Time.time < lastCast; } }  

  public virtual void SetupAction(GameObject casterObject) {
    caster = casterObject;
    casterStats = caster.GetComponent<Stats>();
  }

  public virtual void Perform(GameObject target, GameObject caster) { lastCast = Time.time + cooldown; }

}
