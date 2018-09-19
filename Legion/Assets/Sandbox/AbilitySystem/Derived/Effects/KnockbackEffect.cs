using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(menuName = "Abilities/Effects/Knockback")]
public class KnockbackEffect : AbilityEffect
{
  public float force = 10f;
  public ForceMode forceMode = ForceMode.Force;

  public override void Affect(Ability ability, GameObject target, Vector3 direction)
  {
    base.Affect(ability, target);
    Rigidbody rigidbody = target.GetComponent<Rigidbody>();
    if (rigidbody)
    {     
      rigidbody.AddForce(direction * force, forceMode);
    }
    else
    {
      ImpactReceiver impactReceiver = target.GetComponent<ImpactReceiver>();
      if (impactReceiver) impactReceiver.AddImpact(-target.transform.forward, force);
      else Debug.LogWarning("Target is RigidBody/ImpactReceiver: " + target.name);
    }

  }
}
