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

  public bool isBlocked { get { return blockerController ? blockerController.ContainsBlocker(abilities: true) : false; } }

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
    MainAbility.Setup(gameObject, 1 << targeter.EnemyLayer);
    aggroRange = Math.Max(aggroRange, MainAbility.abilityRange);

    List<AIAbility> instanceAbilities = new List<AIAbility>();
    foreach (AIAbility ability in SecondaryAbilities)
    {
      AIAbility abilityInstance = Instantiate(ability);
      int targetLayer = ability.targetType == TargetType.FRIENDLY ? 1 << targeter.gameObject.layer : 1 << targeter.EnemyLayer;
      abilityInstance.Setup(gameObject, targetLayer);
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
    if (ability.requireLineOfSight)
    {
      return TargetScanner.LineOfSightLayer(targeter.transform, targeter.CurrentTarget, ability.abilityRange, ability);
    }
    return Vector3.Distance(target.transform.position, transform.position) < ability.abilityRange;
  }

  public IEnumerator Cast(AIAbility ability, GameObject target)
  {
    blockerController.AddBlocker(ability.blocker);
    targeter.SetCurrentTarget(target);
    float castTime = ability.castTime;
    animator.SetTrigger(ability.animationTrigger.ToString());

    //if (ability.startEffect)
    //{
    //  ParticleSystem startEffect = Instantiate(ability.startEffect, effectsHolder);
    //  startEffect.Play();
    //  Destroy(startEffect.gameObject, ability.castTime);
    //}

    while (castTime > 0)
    {
      castTime -= 0.5f;
      yield return new WaitForSeconds(Mathf.Min(castTime, 0.5f));
      if (!isValidCast(ability, target))
      {
        // Check for interrupts
        // Should also be interruptable from outside (other character stunning caster or something)
        blockerController.RemoveBlocker(ability.blocker);
        animator.SetTrigger("InterruptCast");
        yield break;
      }
    }

    ability.Cast(target);
    float timeLeft = AnimationTimeLeft();
    //if (ability.onCastEffect)
    //{
    //  ParticleSystem onCastEffect = Instantiate(ability.onCastEffect, effectsHolder);
    //  onCastEffect.Play();
    //  Destroy(onCastEffect.gameObject, Mathf.Max(onCastEffect.main.startLifetime.constant, timeLeft));
    //}

    yield return new WaitForSeconds(timeLeft);
    blockerController.RemoveBlocker(ability.blocker);
  }

  float AnimationTimeLeft()
  {
    AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
    AnimatorClipInfo[] myAnimatorClip = animator.GetCurrentAnimatorClipInfo(0);
    return myAnimatorClip[0].clip.length * animationState.normalizedTime;
  }
}