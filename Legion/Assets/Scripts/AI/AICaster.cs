using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AICaster : AbilityCaster
{
  public Dictionary<int, float> nextCasts;
  public bool isBlocked { get { return blockerController ? blockerController.ContainsBlocker(abilities: true) : false; } }

  BlockerController blockerController;
  Animator animator;
  Transform effectsHolder;
  AIAnimationUpdater aIAnimationUpdater;

  protected override void Start()
  {
    base.Start();
    nextCasts = new Dictionary<int, float>();
    blockerController = GetComponent<BlockerController>();
    animator = GetComponentInChildren<Animator>();
    aIAnimationUpdater = GetComponent<AIAnimationUpdater>();
    effectsHolder = transform.Find("EffectsHolder");

    float maxRange = Mathf.Max(
      mainAttack.range,
      secondaryAttack ? secondaryAttack.range : 15f,
      abilities.Count > 0 ? abilities.Max(x => x.range) : 15f
    );
    ((AITargeter)targeter).SetAggroRange((int)maxRange);
  }

  public override bool TryCast(Ability ability, bool selfCast = false)
  {
    bool foundTarget = targeter.FindTarget(ability);
    return foundTarget && targeter.currentTarget;
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

      // Check for interrupts
      // Should also be interruptable from outside (other character stunning caster or something)
      Debug.Log("Need to test ability. LineOfSight, TargetAlive. E.t.c.");
      //if (!ability.Test(RequirementType.Casting, targeter.currentTarget, false))
      //{
      //  blockerController.RemoveBlocker(ability.blocker);
      //  animator.SetTrigger("InterruptCast");
      //  yield return false;
      //}
    }
    yield return true;
  }
  public IEnumerator Recovery(Ability ability)
  {
    float timeLeft = aIAnimationUpdater.AnimationTimeLeft();
    ActivateEffect(ability.onCastEffect);
    yield return new WaitForSeconds(timeLeft);
    blockerController.RemoveBlocker(ability.blocker);
  }

  // Move this to ParticleManager with pooling e.t.c.
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