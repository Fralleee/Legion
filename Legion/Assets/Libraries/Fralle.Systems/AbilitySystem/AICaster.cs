﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AICaster : MonoBehaviour
{
  public Ability MainAbility;
  public List<Ability> SecondaryAbilities;
  AITargeter targeter;
  BlockerController blockerController;
  [SerializeField] Blocker blocker;

  public bool AIMagicAttack1;

  public bool IsBlocked { get { return blockerController.ContainsBlocker(abilities: true); } }

  void Start()
  {
    targeter = GetComponent<AITargeter>();
    blockerController = GetComponent<BlockerController>();
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
    AIMagicAttack1 = true;
    Debug.Log(AIMagicAttack1);
    if (!target)
    {
      blockerController.RemoveBlocker(blocker);
      AIMagicAttack1 = false;
      yield break;
    }

    targeter.SetCurrentTarget(target);
    yield return new WaitForSeconds(ability.WindupTime);

    if (!target)
    {
      AIMagicAttack1 = false;
      blockerController.RemoveBlocker(blocker);
      yield break;
    }

    ability.Cast(target);
    AIMagicAttack1 = false;
    yield return new WaitForSeconds(ability.RecoveryTime);
    blockerController.RemoveBlocker(blocker);
  }

  //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((CurrentTarget.transform.position - transform.position).normalized), Time.deltaTime * 4f);
  //transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((CurrentTarget.transform.position - transform.position).normalized), Time.deltaTime * 4f);
}