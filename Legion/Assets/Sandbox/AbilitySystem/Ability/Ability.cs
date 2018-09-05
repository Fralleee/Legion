using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum AbilityTargetTeam { Hostile, Ally }
public enum AbilityCastType { Active, Passive, Toggle, Channel }
public enum AbilityTargetType { Target, Direction, Point }

public abstract class Ability : ScriptableObject
{
  public Blocker blocker;
  [Space(5)]

  [Header("Settings")]
  public Image image;
  public float range = 15f;
  public float cooldown = 2;
  public float castTime = 1f;
  public bool transferEffectsToPrefab;
  public AbilityTargetTeam targetTeam = AbilityTargetTeam.Hostile;
  public AbilityCastType castType = AbilityCastType.Active;
  public AbilityTargetType targetType = AbilityTargetType.Target;
  public AbilityRequirement[] requirements;
  public List<AbilityEffect> effects = new List<AbilityEffect>();
  [Space(10)]

  [Header("Visuals")]
  public AnimationTrigger animationTrigger;
  public ParticleSystem startEffect;
  public ParticleSystem onCastEffect;

  protected float nextTest;
  protected float testRate;

  [HideInInspector] public float lastAction;
  public bool isReady { get { return Time.time > lastAction; } }
  [HideInInspector] public AbilityCaster owner;
  [HideInInspector] public int environmentLayer;
  [HideInInspector] public int targetLayer;

  public void Setup(AbilityCaster caster)
  {
    owner = caster;
    lastAction = 0;
    environmentLayer = LayerMask.NameToLayer("Environment");
    targetLayer = targetTeam == AbilityTargetTeam.Hostile ? owner.hostileLayer : owner.friendlyLayer;
  }

  public virtual void Cast(bool selfCast = false) { lastAction = Time.time + cooldown; }

  public bool Test(RequirementType type, GameObject target, bool selfCast = false)
  {
    bool result;
    if (type == RequirementType.All)
    {
      result = requirements.All(x => x.Test(owner, this, target, selfCast));
      return result;
    }

    result = requirements.Where(x => x.requirementType == type || x.requirementType == RequirementType.All).All(x => x.Test(owner, this, target, selfCast));
    return result;
  }
}
