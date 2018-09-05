//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//public class CharacterCaster : AbilityCaster
//{
//  void Update()
//  {
//    for (int i = 0; i < abilities.Count; i++)
//    {
//      if (Input.GetKeyDown(KeyCode.Alpha1 + i))
//      {
//        bool result = TryCast(abilities[i], Input.GetKey(KeyCode.LeftAlt));
//        if(result) abilities[i].Cast(Input.GetKey(KeyCode.LeftAlt));
//      }
//    }
//  }

//  protected override bool TryCast(Ability ability, bool selfCast = false)
//  {
//    if(ability.targetType == AbilityTargetType.Target) return ability.Test(RequirementType.All, targeter.currentTarget, selfCast);
//    return true;
//  }

//  public override void TargetCast(TargetAbility ability, bool selfCast)
//  {
//    if (selfCast)
//    {
//      Instantiate(ability.prefab, transform.position, Quaternion.identity, transform);
//      return;
//    }
//    if (!targeter.currentTarget) return;
//    if (ability.targetTeam == AbilityTargetTeam.Ally && targeter.currentTarget.layer != friendlyLayer) return;
//    if (ability.targetTeam == AbilityTargetTeam.Hostile && targeter.currentTarget.layer != hostileLayer) return;
//    GameObject instance = Instantiate(ability.prefab, targeter.currentTarget.transform.position, Quaternion.identity);
//  }

//  public override void PointCast(PointAbility ability)
//  {
//    Vector3 position = transform.position + transform.forward * ability.range;
//    GameObject instance = Instantiate(ability.prefab, new Vector3(position.x, 0, position.z), Quaternion.identity);
//  }

//  public override void DirectionCast(DirectionAbility ability)
//  {
//    GameObject instance = Instantiate(ability.prefab, transform.position + transform.forward, transform.rotation);
//  }

//}
