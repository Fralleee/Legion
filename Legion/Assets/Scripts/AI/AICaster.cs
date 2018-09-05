using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : AbilityCaster
{
  public Ability MainAbility;
  public bool isBlocked { get { return blockerController ? blockerController.ContainsBlocker(abilities: true) : false; } }
  BlockerController blockerController;
  Animator animator;
  Transform effectsHolder;

  Dictionary<int, float> nextCasts = new Dictionary<int, float>();

  protected override void Start()
  {
    base.Start();
    blockerController = GetComponent<BlockerController>();
    animator = GetComponentInChildren<Animator>();
    effectsHolder = transform.Find("EffectsHolder");
    Initialize();
  }

  void Initialize()
  {
    MainAbility = Instantiate(MainAbility);
    MainAbility.Setup(this);
  }


  public override bool TryCast(Ability ability, bool selfCast = false)
  {
    bool foundTarget = targeter.FindTarget(ability);
    if (foundTarget && targeter.currentTarget)
    {
      if (!(targeter.currentTarget.gameObject.layer == friendlyLayer && ability.targetTeam == AbilityTargetTeam.Ally)) return false;
      if (!(targeter.currentTarget.gameObject.layer == hostileLayer && ability.targetTeam == AbilityTargetTeam.Hostile)) return false;
      bool result = ability.Test(RequirementType.Casting, targeter.currentTarget, selfCast);
      return result;
    }
    return false;
  }


  public override IEnumerator TargetCast(TargetAbility ability, bool selfCast = false)
  {
    CoroutineWithResponse cwr = new CoroutineWithResponse(this, Windup(ability));
    yield return cwr.coroutine;
    if ((bool)cwr.result)
    {
      if (selfCast)
      {
        Instantiate(ability.prefab, transform.position, Quaternion.identity, transform);
        yield break;
      }
    }
    yield return Recovery(ability);
    GameObject instance = Instantiate(ability.prefab, targeter.currentTarget.transform.position, Quaternion.identity);
  }
  public override IEnumerator PointCast(PointAbility ability)
  {
    CoroutineWithResponse cwr = new CoroutineWithResponse(this, Windup(ability));
    yield return cwr.coroutine;
    if ((bool)cwr.result)
    {
      Vector3 position = targeter.currentTarget.transform.position;
      GameObject instance = Instantiate(ability.prefab, new Vector3(position.x, 0, position.z), Quaternion.identity);
    }
    yield return Recovery(ability);
  }
  public override IEnumerator DirectionCast(DirectionAbility ability)
  {
    CoroutineWithResponse cwr = new CoroutineWithResponse(this, Windup(ability));
    yield return cwr.coroutine;
    if ((bool)cwr.result)
    {
      GameObject instance = Instantiate(ability.prefab, transform.position + transform.forward, transform.rotation);
    }
    yield return Recovery(ability);
  }

  public IEnumerator Windup(Ability ability)
  {
    blockerController.AddBlocker(ability.blocker);
    float castTime = ability.castTime;
    animator.SetTrigger(ability.animationTrigger.ToString());
    ActivateEffect(ability.startEffect, ability.castTime);
    while (castTime > 0)
    {
      castTime -= 0.5f;
      yield return new WaitForSeconds(Mathf.Min(castTime, 0.5f));
      if (!ability.Test(RequirementType.Casting, targeter.currentTarget, false))
      {
        // Check for interrupts
        // Should also be interruptable from outside (other character stunning caster or something)
        blockerController.RemoveBlocker(ability.blocker);
        animator.SetTrigger("InterruptCast");
        yield return false;
      }
    }
    yield return true;
  }
  public IEnumerator Recovery(Ability ability)
  {
    float timeLeft = AnimationTimeLeft();
    ActivateEffect(ability.onCastEffect);
    yield return new WaitForSeconds(timeLeft);
    blockerController.RemoveBlocker(ability.blocker);
  }


  float AnimationTimeLeft()
  {
    AnimatorStateInfo animationState = animator.GetCurrentAnimatorStateInfo(0);
    AnimatorClipInfo[] myAnimatorClip = animator.GetCurrentAnimatorClipInfo(0);
    return myAnimatorClip[0].clip.length * animationState.normalizedTime;
  }
  void ActivateEffect(ParticleSystem effect, float time = -1f)
  {
    if (effect)
    {
      ParticleSystem onCastEffect = Instantiate(effect, effectsHolder);
      onCastEffect.Play();
      Destroy(onCastEffect.gameObject, time > 0 ? time : onCastEffect.main.startLifetime.constant);
    }
  }
}