using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AICaster : AbilityCaster
{
  public bool isBlocked { get { return blockerController ? blockerController.ContainsBlocker(abilities: true) : false; } }
  BlockerController blockerController;
  Animator animator;
  Transform effectsHolder;
  AIAnimationUpdater aIAnimationUpdater;
  AIMotor motor;

  protected override void Start()
  {
    base.Start();
    blockerController = GetComponent<BlockerController>();
    motor = GetComponent<AIMotor>();
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
    ability.lastAction = Time.time + 0.5f;
    bool foundTarget = targeter.FindTarget(ability);
    return foundTarget && targeter.currentTarget;
  }

  public bool TryCastMainTarget(Ability ability)
  {
    bool validTarget = ability.Test(targeter.mainTarget);
    targeter.currentTarget = targeter.mainTarget;
    return validTarget;
  }

  public override IEnumerator TargetCast(TargetAbility ability, bool selfCast = false)
  {
    CoroutineWithResponse cwr = new CoroutineWithResponse(this, Windup(ability));
    yield return cwr.coroutine;
    if ((bool)cwr.result)
    {
      ability.ApplyEffects(targeter.currentTarget);
      ability.ApplyCooldown();
      if(ability.prefab) Instantiate(ability.prefab, targeter.currentTarget.transform.position, Quaternion.identity);
      yield return Recovery(ability);
    }
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
      GameObject instance = Instantiate(ability.prefab, transform.position + transform.up + transform.forward, transform.rotation);
      instance.layer = targeter.GetSpawnLayer();
      instance.GetComponent<AbilityProjectile>().ability = ability;
      if (ability.transferEffectsToPrefab) instance.GetComponent<AbilityProjectile>().effects = ability.effects;
      ability.ApplyCooldown();
      yield return Recovery(ability);
    }
  }
  public IEnumerator Windup(Ability ability)
  {
    blockerController.AddBlocker(ability.blocker);
    motor.turnTowardsTarget = targeter.currentTarget;
    float castTime = ability.castTime;
    animator.SetTrigger(ability.animationTrigger.ToString());
    ActivateEffect(ability.startEffect, ability.castTime);
    while (castTime > 0)
    {
      castTime -= 0.5f;
      yield return new WaitForSeconds(Mathf.Min(castTime, 0.5f));
      if (!ability.Test(targeter.currentTarget))
      {
        // Check for interrupts
        // Should also be interruptable from outside (other character stunning caster or something)
        motor.turnTowardsTarget = null;
        blockerController.RemoveBlocker(ability.blocker);
        animator.SetTrigger("InterruptCast");
        yield return false;
        yield break;
      }
    }
    yield return true;
  }
  public IEnumerator Recovery(Ability ability)
  {
    float timeLeft = Mathf.Max(aIAnimationUpdater.AnimationTimeLeft(), 1f);
    ActivateEffect(ability.onCastEffect);
    yield return new WaitForSeconds(timeLeft);
    motor.turnTowardsTarget = null;
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