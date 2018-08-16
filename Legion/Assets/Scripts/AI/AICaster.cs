using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : MonoBehaviour
{
  [SerializeField] Blocker blocker;
  public Ability MainAbility;
  public List<Ability> SecondaryAbilities;
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
    MainAbility.IsMainAbility = true;
    MainAbility.Setup(gameObject);
    aggroRange = Math.Max(aggroRange, MainAbility.AbilityRange);

    List<Ability> instanceAbilities = new List<Ability>();
    foreach (Ability ability in SecondaryAbilities)
    {
      Ability abilityInstance = Instantiate(ability);
      abilityInstance.IsMainAbility = false;
      abilityInstance.Setup(gameObject);
      instanceAbilities.Add(abilityInstance);
      if (ability.targetType == TargetType.HOSTILE) aggroRange = Math.Max(aggroRange, ability.AbilityRange);
    }
    SecondaryAbilities = instanceAbilities;
    targeter.SetAggroRange(aggroRange);
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