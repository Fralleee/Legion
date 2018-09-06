using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AbilityCaster : MonoBehaviour
{
  [HideInInspector] public int hostileLayer;
  [HideInInspector] public int friendlyLayer;

  public Ability mainAttack;
  public Ability secondaryAttack;
  public List<Ability> abilities;
  protected ITargeter targeter;

  protected virtual void Awake()
  {
    hostileLayer = LayerMask.NameToLayer("Targets");
    friendlyLayer = gameObject.layer;
    targeter = GetComponent<ITargeter>();
  }

  protected virtual void Start()
  {
    mainAttack = mainAttack.Setup(this);
    if (secondaryAttack) secondaryAttack = secondaryAttack.Setup(this);
    abilities.Where(x => x.castType == AbilityCastType.Passive).ToList().ForEach(x => TargetCast((TargetAbility)x.Setup(this), true));
    abilities.Where(x => x.castType != AbilityCastType.Passive).ToList().ForEach(x => x = x.Setup(this));
  }

  public abstract bool TryCast(Ability ability, bool selfCast = false);
  public abstract IEnumerator TargetCast(TargetAbility ability, bool selfCast = false);
  public abstract IEnumerator PointCast(PointAbility ability);
  public abstract IEnumerator DirectionCast(DirectionAbility ability);

}
