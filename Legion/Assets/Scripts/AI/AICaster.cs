using System;
using System.Collections;
using UnityEngine;

// REPLACE THIS
public enum CastAnimations
{
  AimedTrigger,
  AreaTrigger,
  DirectTrigger
}

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : AbilityCaster
{
  BlockerController blockerController;
  [SerializeField] Blocker blocker;
  Animator animator;
  Transform effectsHolder;

  public bool IsBlocked { get { return blockerController.ContainsBlocker(abilities: true); } }

  protected override void Start()
  {
    base.Start();
    blockerController = GetComponent<BlockerController>();
    animator = GetComponentInChildren<Animator>();
    effectsHolder = transform.Find("EffectsHolder");
  }

  public bool TryCast(Ability ability)
  {
    GameObject target = ability.FindTarget(targeter);
    if (target == null) return false;

    blockerController.AddBlocker(blocker);
    StartCoroutine(Cast(ability, target));
    return true;
  }

  public IEnumerator Cast(Ability ability, GameObject target)
  {
    animator.SetBool("Casting", true);

    ParticleSystem castingEffect = Instantiate(ability.castingEffect, effectsHolder);
    castingEffect.Play();
    if (!target)
    {
      blockerController.RemoveBlocker(blocker);
      animator.SetBool(ability.CastAnimation.ToString(), false);
      yield break;
    }

    targeter.SetCurrentTarget(target);
    yield return new WaitForSeconds(ability.WindupTime);

    if (!target)
    {
      animator.SetBool("Casting", false);
      blockerController.RemoveBlocker(blocker);
      yield break;
    }

    animator.SetTrigger(ability.CastAnimation.ToString());
    ExplodeCastingParticles(castingEffect);
    ability.Cast(target);

    yield return new WaitForSeconds(Math.Max(ability.RecoveryTime, 0.5f));
    animator.SetBool("Casting", false);

    blockerController.RemoveBlocker(blocker);
  }

  void ExplodeCastingParticles(ParticleSystem castingEffect)
  {
    ParticleSystem.MainModule main = castingEffect.main;
    main.startLifetime = 0.35f;
    main.startSpeed = 3;
    main.gravityModifier = 0.25f;
    castingEffect.Emit(50);
    Destroy(castingEffect.gameObject, castingEffect.main.startLifetime.constant);
  }
}