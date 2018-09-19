using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterCaster : AbilityCaster
{
  new Targeter targeter;
  DamageController damageController;
  [SerializeField] Transform leftHand;
  [SerializeField] Transform rightHand;

  protected override void Awake()
  {
    base.Awake();
    targeter = GetComponent<Targeter>();
    damageController = GetComponent<DamageController>();
  }

  void Update()
  {
    for (int i = 0; i < abilities.Count; i++)
    {
      if (!Input.GetKeyDown(KeyCode.Alpha1 + i)) continue;
      bool result = TryCast(abilities[i], Input.GetKey(KeyCode.LeftAlt));
      if (result) abilities[i].Cast(Input.GetKey(KeyCode.LeftAlt));
    }
  }

  public override bool TryCast(Ability ability, bool selfCast = false)
  {
    if (ability.GetType() == typeof(TargetAbility))
      return (selfCast || targeter.currentTarget);
    return true;
  }

  public override void PassiveCast(TargetAbility ability)
  {
    ability.ApplyEffects(gameObject);
    if (ability.prefab) Instantiate(ability.prefab, transform);
  }

  public override IEnumerator TargetCast(TargetAbility ability, bool selfCast)
  {
    if (selfCast)
    {
      Instantiate(ability.prefab, transform.position, Quaternion.identity, transform);
      yield break;
    }
    if (!targeter.currentTarget) yield break;
    if (ability.targetTeam == AbilityTargetTeam.Ally && targeter.currentTarget.gameObject.layer != gameObject.layer) yield break;
    if (ability.targetTeam == AbilityTargetTeam.Hostile && targeter.currentTarget.gameObject.layer != targeter.enemyLayer) yield break;
    GameObject instance = Instantiate(ability.prefab, targeter.currentTarget.transform.position, Quaternion.identity);

  }

  public override IEnumerator PointCast(PointAbility ability)
  {
    Vector3 position = transform.position + transform.forward * ability.range;
    GameObject instance = Instantiate(ability.prefab, new Vector3(position.x, 0, position.z), Quaternion.identity);
    yield break;
  }

  public override IEnumerator DirectionCast(DirectionAbility ability)
  {
    Vector3 spawnPosition = transform.position;
    switch (ability.instantiationSettings.InstantiationPosition)
    {
      case CasterInstantiationPosition.CasterFeet: spawnPosition = transform.position; break;
      case CasterInstantiationPosition.CasterCenter: spawnPosition = damageController.model.bounds.center; break;
      case CasterInstantiationPosition.CasterHead: spawnPosition = transform.position.With(y: damageController.model.bounds.max.y); break;
      case CasterInstantiationPosition.CasterLeftHand: spawnPosition = leftHand.position; break;
      case CasterInstantiationPosition.CasterRightHand: spawnPosition = rightHand.position; break;
      default: break;
    }
    GameObject instance = Instantiate(ability.prefab, spawnPosition, transform.rotation);
    instance.layer = targeter.spawnLayer;
    instance.GetComponent<AbilityProjectile>().ability = ability;
    if (ability.transferEffectsToPrefab) instance.GetComponent<AbilityProjectile>().effects = ability.effects;
    ability.ApplyCooldown();
    yield break;
  }

}
