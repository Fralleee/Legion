using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterCaster : AbilityCaster
{
  new Targeter targeter;
  DamageController damageController;
  Animator animator;

  Ability activeAbility;
  GameObject targetIndicator;

  [SerializeField] Transform leftHand;
  [SerializeField] Transform rightHand;
  bool siegeMode;
  public enum PrimaryCastAnimation { PrimaryCastRight, PrimaryCastLeft }
  PrimaryCastAnimation currentCastAnimation = PrimaryCastAnimation.PrimaryCastRight;

  protected override void Awake()
  {
    base.Awake();
    targeter = GetComponent<Targeter>();
    animator = GetComponentInChildren<Animator>();
    damageController = GetComponent<DamageController>();
  }

  void Update()
  {
    if (!activeAbility) targetIndicator = null;

    for (int i = 0; i < abilities.Count; i++)
    {
      if (!Input.GetKeyDown(KeyCode.Alpha1 + i)) continue;
      activeAbility = abilities[i];
      SetupTargetIndicator(activeAbility);
    }

    if (activeAbility && Input.GetButtonDown("Fire1"))
    {
      bool result = TryCast(activeAbility, Input.GetKey(KeyCode.LeftAlt));
      if (result) activeAbility.Cast(Input.GetKey(KeyCode.LeftAlt));
      activeAbility = null;
      Destroy(targetIndicator);
      targetIndicator = null;
    }

    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      animator.SetTrigger(currentCastAnimation.ToString());
      currentCastAnimation = currentCastAnimation == PrimaryCastAnimation.PrimaryCastRight
        ? PrimaryCastAnimation.PrimaryCastLeft
        : PrimaryCastAnimation.PrimaryCastRight;
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      animator.SetTrigger("AOECast");
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      siegeMode = !siegeMode;
      animator.SetBool("SiegeMode", siegeMode);
    }

    if (targetIndicator) UpdateTargetIndicator();
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
    float yPos = 0f;
    switch (ability.instantiationSettings.InstantiationPosition)
    {
      case PointInstantiationPosition.Ground: yPos = 0f; break;
    }
    GameObject instance = Instantiate(ability.prefab, new Vector3(targetIndicator.transform.position.x, yPos, targetIndicator.transform.position.z), Quaternion.identity);
    instance.GetComponent<PointAbilityInstance>().ApplyEffects(ability);

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

  void SetupTargetIndicator(Ability ability)
  {
    if(targetIndicator)
    {
      Destroy(targetIndicator);
      targetIndicator = null;
    }

    // Instead of all this code in character caster
    // Set this to targetindicator-script
    if (ability is TargetAbility)
    {
      // Use currentTarget
      // Change material of currentTarget
    }

    else if (ability is DirectionAbility)
    {
      // Use a projector to indicate which direction
      // Decals
    }
    else if (ability is PointAbility)
    {
      // Use a projector to indicate position and range
      Projector abilityTargetIndicator = ((PointAbility)ability).targetIndicator;
      targetIndicator = Instantiate(abilityTargetIndicator.gameObject, transform.position, Quaternion.Euler(90, 0, 0), transform);
    }
  }

  void UpdateTargetIndicator()
  {
    if (!targetIndicator) return;

    float camXRot = Camera.main.transform.eulerAngles.x;
    float zPosition = (60 - camXRot) / 4;

    zPosition = Mathf.Clamp(zPosition, 0, activeAbility.range);
    Vector3 position = transform.position + transform.forward * zPosition;

    targetIndicator.transform.position = position;
  }

}
