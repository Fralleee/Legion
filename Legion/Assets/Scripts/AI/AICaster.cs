using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : MonoBehaviour
{
  [SerializeField] Blocker blocker;
  public AIAbility MainAbility;
  public List<AIAbility> SecondaryAbilities;
  public bool IsBlocked { get { return blockerController.ContainsBlocker(abilities: true); } }

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

    List<AIAbility > instanceAbilities = new List<AIAbility>();
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
  public IEnumerator Cast(AIAbility ability, GameObject target)
  {
    // Windup
    targeter.SetCurrentTarget(target);
    blockerController.AddBlocker(ability.windupBlocker);
    animator.SetBool(ability.windupAnimation.ToString(), true);
    ParticleSystem windupEffect = Instantiate(ability.windupEffect, effectsHolder);
    windupEffect.Play();

    yield return new WaitForSeconds(ability.windupTime);
    Destroy(windupEffect.gameObject);
    if (!target)
    {
      animator.SetBool(ability.windupAnimation.ToString(), false);
      blockerController.RemoveBlocker(ability.windupBlocker);
      yield break;
    }
    else
    {
      // Cast & Recovery
      animator.SetTrigger(ability.castAnimation.ToString());
      blockerController.RemoveBlocker(ability.windupBlocker);
      blockerController.AddBlocker(ability.recoveryBlocker);
      ParticleSystem castingEffect = Instantiate(ability.castingEffect, effectsHolder);
      castingEffect.Play();
      Destroy(castingEffect.gameObject, castingEffect.main.startLifetime.constant);
      ability.Cast(target);

      yield return new WaitForSeconds(Math.Max(ability.recoveryTime, 0.5f));
      animator.SetBool(ability.windupAnimation.ToString(), false);
      blockerController.RemoveBlocker(ability.recoveryBlocker);
    }
  }
}