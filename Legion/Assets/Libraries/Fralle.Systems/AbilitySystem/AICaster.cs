using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CastAnimation
{
  QuickCast1,
  LargeCast1
}

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : MonoBehaviour
{
  public Ability MainAbility;
  public List<Ability> SecondaryAbilities;
  AITargeter targeter;
  BlockerController blockerController;
  [SerializeField] Blocker blocker;
  Animator animator;

  public bool IsBlocked { get { return blockerController.ContainsBlocker(abilities: true); } }

  void Start()
  {
    targeter = GetComponent<AITargeter>();
    blockerController = GetComponent<BlockerController>();
    animator = GetComponentInChildren<Animator>();
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
    GameObject target = ability.FindTargets(targeter);
    if (target == null) return false;

    blockerController.AddBlocker(blocker);
    StartCoroutine(Cast(ability, target));
    return true;
  }

  public IEnumerator Cast(Ability ability, GameObject target)
  {
    animator.SetBool(ability.Animation.ToString(), true);
    if (!target)
    {
      blockerController.RemoveBlocker(blocker);
      animator.SetBool(ability.Animation.ToString(), false);
      yield break;
    }

    targeter.SetCurrentTarget(target);
    yield return new WaitForSeconds(ability.WindupTime);

    if (!target)
    {
      animator.SetBool(ability.Animation.ToString(), false);
      blockerController.RemoveBlocker(blocker);
      yield break;
    }

    ability.Cast(target);
    animator.SetBool(ability.Animation.ToString(), false);
    yield return new WaitForSeconds(ability.RecoveryTime);
    blockerController.RemoveBlocker(blocker);
  }
}