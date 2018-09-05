//using UnityEngine;
//using System;
//using System.Linq;

//[CreateAssetMenu(menuName = "Abilities/Target")]
//public class TargetAbility : AIAbility
//{
//  [Header("Target Ability Specific")]
//  public TargetReceiver targetReceiver = TargetReceiver.TARGET;
//  [HideInInspector] public float aoeRadius = 1; // Only applicable if targetlocation
//  [HideInInspector] public ParticleSystem locationEffect; // Only applicable if targetlocation
//  public override void Setup(GameObject casterGo, int targetLayerParam) { base.Setup(casterGo, targetLayerParam); }

//  public override void Cast(GameObject target)
//  {
//    base.Cast(target);
//    switch (targetReceiver)
//    {
//      case TargetReceiver.TARGET:
//        TargetCast(target);
//        break;
//      case TargetReceiver.LOCATION:
//        LocationCast(target.transform.position);
//        break;
//      default:
//        TargetCast(target);
//        break;
//    }
//  }
//  void TargetCast(GameObject target)
//  {
//    foreach (AbilityEffect effect in effects)
//    {
//      effect.Affect(this, target);
//    }
//  }

//  void LocationCast(Vector3 position)
//  {
//    Debug.DrawRay(caster.transform.position, position, Color.blue, 1f);
//    Collider[] colliders = Physics.OverlapSphere(position, aoeRadius, targetLayer);
//    colliders = colliders.Where(x => x.GetComponent<DamageController>()).ToArray();
//    foreach (Collider col in colliders)
//    {
//      foreach (AbilityEffect effect in effects)
//      {
//        effect.Affect(this, col.gameObject);
//      }
//    }
//    if (locationEffect)
//    {
//      ParticleSystem effect = Instantiate(locationEffect, position, Quaternion.identity);
//      effect.Play();
//      Destroy(effect.gameObject, effect.main.startLifetime.constant);
//    }
//  }
//}