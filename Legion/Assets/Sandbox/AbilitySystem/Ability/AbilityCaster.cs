using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AbilityCaster : MonoBehaviour
{
  public Ability mainAttack;
  public Ability secondaryAttack;
  public List<Ability> abilities;
  public ITargeter targeter;

  protected virtual void Awake()
  {
    targeter = GetComponent<ITargeter>();
  }

  protected virtual void Start()
  {
    mainAttack = mainAttack.Setup(this);
    if (secondaryAttack) secondaryAttack = secondaryAttack.Setup(this);
    for (int i = 0; i < abilities.Count; i++)
    {
      abilities[i] = abilities[i].Setup(this);
    }
    abilities.Where(x => x.castType == AbilityCastType.Passive).ToList().ForEach(x => PassiveCast((TargetAbility)x.Setup(this)));
    abilities = abilities.Where((x => x.castType != AbilityCastType.Passive)).ToList();
    abilities.Select(x => x.Setup(this));
  }

  public abstract bool TryCast(Ability ability, bool selfCast = false);
  public abstract void PassiveCast(TargetAbility ability);
  public abstract IEnumerator TargetCast(TargetAbility ability, bool selfCast = false);
  public abstract IEnumerator PointCast(PointAbility ability);
  public abstract IEnumerator DirectionCast(DirectionAbility ability);

}
