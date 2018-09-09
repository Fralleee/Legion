﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum AbilityLineOfSight { Team, Target, NotRequired }
public enum AbilityPriority { LowHealth, HighHealth, Nearest, Furthest, UseCasterPriority, None }
public enum AbilityTargetTeam { Hostile, Ally }
public enum AbilityCastType { Active, Passive, Toggle, Channel }
public enum AbilityTargetType { Target, Direction, Point }
public enum AnimationTrigger { Swing, Slash, Cast }

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
  public AbilityLineOfSight requireLineOfSight = AbilityLineOfSight.Target;
  public AbilityPriority priority = AbilityPriority.Nearest;
  public AbilityTargetTeam targetTeam = AbilityTargetTeam.Hostile;
  public AbilityCastType castType = AbilityCastType.Active;
  public AbilityTargetType targetType = AbilityTargetType.Target;
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

  public Ability Setup(AbilityCaster caster)
  {
    Ability instance = Instantiate(this);
    instance.owner = caster;
    instance.lastAction = 0;
    instance.environmentLayer = LayerMask.NameToLayer("Environment");
    instance.targetLayer = caster.targeter.GetTargetLayer(targetTeam);
    return instance;
  }

  public abstract void Cast(bool selfCast = false);
  public virtual void PerformedCast() { lastAction = Time.time + cooldown; }
  public virtual bool Test(Transform target)
  {
    bool targetIsAlive = target && target.gameObject && target.gameObject.activeSelf;
    if (!targetIsAlive) return false;

    LayerMask targetMask = 1 << targetLayer;
    LayerMask environmentMask = 1 << environmentLayer;
    switch (requireLineOfSight)
    {
      case AbilityLineOfSight.Target:
        {
          bool result = TargetingHelpers.LineOfSightUnObstructed(owner.transform, target, range, targetMask, environmentMask);
          return result;
        }
      case AbilityLineOfSight.Team:
        {
          bool result = TargetingHelpers.LineOfSightLayer(owner.transform, target, range, targetMask, environmentMask);
          return result;
        }
      case AbilityLineOfSight.NotRequired:
        {
          bool result = Vector3.Distance(owner.transform.position, target.position) < range;
          return result;
        }
      default: return false;
    }
  }
}