using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : MonoBehaviour
{
  public AIAbility MainAbility;
  public List<AIAbility> SecondaryAbilities;

  public bool IsBlocked { get { return blockerController ? blockerController.ContainsBlocker(abilities: true) : false; } }

  AITargeter targeter;
  BlockerController blockerController;
  Animator animator;
  Transform effectsHolder;

  void Start()
  {
    targeter = GetComponent<AITargeter>();
    blockerController = GetComponent<BlockerController>();
    animator = GetComponentInChildren<Animator>();
    effectsHolder = transform.Find("EffectsHolder");
    Initialize();
  }
  void Initialize()
  {
    int aggroRange = 0;
    MainAbility = Instantiate(MainAbility);
    MainAbility.Setup(gameObject);
    aggroRange = Math.Max(aggroRange, MainAbility.abilityRange);

    List<AIAbility> instanceAbilities = new List<AIAbility>();
    foreach (AIAbility ability in SecondaryAbilities)
    {
      AIAbility abilityInstance = Instantiate(ability);
      abilityInstance.Setup(gameObject);
      instanceAbilities.Add(abilityInstance);
      if (ability.targetType == TargetType.HOSTILE) aggroRange = Math.Max(aggroRange, ability.abilityRange);
    }
    SecondaryAbilities = instanceAbilities;
    targeter.SetAggroRange(aggroRange);
  }
  public bool TryCast()
  {
    GameObject target = TargetScanner.ValidateMainTarget(MainAbility, targeter);
    if (target == null) return false;
    StartCoroutine(Cast(MainAbility, target));
    return true;
  }
  public bool TryCast(AIAbility ability)
  {
    GameObject target = TargetScanner.FindTargetForAbility(ability, targeter);
    if (target == null) return false;
    StartCoroutine(Cast(ability, target));
    return true;
  }

  bool isValidCast(AIAbility ability, GameObject target)
  {
    if (!target) return false;
    if (ability.requireLineOfSight) return TargetScanner.LineOfSightLayer(targeter.MainTarget, targeter.transform, ability.abilityRange);
    return Vector3.Distance(target.transform.position, transform.position) < ability.abilityRange;
  }
  public IEnumerator Cast(AIAbility ability, GameObject target)
  {
    // Windup
    targeter.SetCurrentTarget(target);
    animator.SetBool(ability.windupAnimation.ToString(), true);
    blockerController.AddBlocker(ability.windupBlocker);
    if (ability.windupEffect)
    {
      ParticleSystem windupEffect = Instantiate(ability.windupEffect, effectsHolder);
      windupEffect.Play();
      Destroy(windupEffect.gameObject, ability.windupTime);
    }

    yield return new WaitForSeconds(ability.windupTime);
    if (!isValidCast(ability, target))
    {
      animator.SetBool(ability.windupAnimation.ToString(), false);
      blockerController.RemoveBlocker(ability.windupBlocker);
      yield break;
    }

    // Cast & Recovery
    animator.SetTrigger(ability.castAnimation.ToString());
    blockerController.RemoveBlocker(ability.windupBlocker);
    blockerController.AddBlocker(ability.recoveryBlocker);
    if (ability.castingEffect)
    {
      ParticleSystem castingEffect = Instantiate(ability.castingEffect, effectsHolder);
      castingEffect.Play();
      Destroy(castingEffect.gameObject, castingEffect.main.startLifetime.constant);
    }
    ability.Cast(target);

    yield return new WaitForSeconds(Math.Max(ability.recoveryTime, 0.5f));
    animator.SetBool(ability.windupAnimation.ToString(), false);
    blockerController.RemoveBlocker(ability.recoveryBlocker);
  }
}