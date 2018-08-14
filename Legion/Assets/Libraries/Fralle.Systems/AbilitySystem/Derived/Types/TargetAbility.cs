using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Abilities/Target")]
public class TargetAbility : Ability
{
  [Header("Target Ability Specific")]
  public TargetReceiver targetReceiver = TargetReceiver.TARGET;
  [HideInInspector] public float aoeRadius = 1; // Only applicable if targetlocation
  [HideInInspector] public GameObject locationEffect; // Only applicable if targetlocation

  void OnEnable()
  {
    CastAnimation = CastAnimations.AimedTrigger;  
  }
  public override void Setup(GameObject caster) { base.Setup(caster); }
  public override void Cast(GameObject target)
  {
    base.Cast(target);
    switch (targetReceiver)
    {
      case TargetReceiver.TARGET:
        TargetCast(target);
        break;
      case TargetReceiver.LOCATION:
        throw new NotImplementedException();
      //LocationCast(target.transform.position);
      default:
        TargetCast(target);
        break;
    }
  }
  void TargetCast(GameObject target)
  {
    foreach (AbilityEffect effect in effects)
    {
      effect.Affect(this, target);
    }
  }
}