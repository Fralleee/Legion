using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AITargeter))]
public abstract class AbilityCaster : MonoBehaviour
{
  public Ability MainAbility;
  public List<Ability> SecondaryAbilities;
  protected AITargeter targeter;

  protected virtual void Start()
  {
    targeter = GetComponent<AITargeter>();
    Initialize();
  }

  protected virtual void Initialize()
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
}
