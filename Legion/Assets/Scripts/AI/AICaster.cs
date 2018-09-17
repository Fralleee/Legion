using Fralle;
using System.Collections;
using System.Linq;
using UnityEngine;

public class AICaster : AbilityCaster
{
  public bool isBlocked { get { return blockerController && blockerController.Abilities; } }
  BlockerController blockerController;
  Animator animator;
  Transform effectsHolder;
  AIAnimationUpdater aIAnimationUpdater;
  AIMotor motor;
  DamageController damageController;

  [SerializeField] Transform leftHand;
  [SerializeField] Transform rightHand;

  protected override void Awake()
  {
    base.Awake();
    blockerController = GetComponent<BlockerController>();
    motor = GetComponent<AIMotor>();
    animator = GetComponentInChildren<Animator>();
    aIAnimationUpdater = GetComponent<AIAnimationUpdater>();
    damageController = GetComponent<DamageController>();
    effectsHolder = transform.Find("EffectsHolder");
  }

  protected override void Start()
  {
    base.Start();
    float maxRange = Mathf.Max(
      mainAttack.range,
      secondaryAttack ? secondaryAttack.range : 15f,
      abilities.Count > 0 ? abilities.Max(x => x.range) : 15f
    );
    ((AITargeter)targeter).SetAggroRange((int)maxRange);
  }

  public override bool TryCast(Ability ability, bool selfCast = false)
  {
    ability.lastAction = Time.time + 0.5f;
    bool foundTarget = targeter.FindTarget(ability);
    return foundTarget && targeter.currentTarget;
  }

  public bool TryCastMainTarget(Ability ability)
  {
    bool validTarget = ability.Test(targeter.mainTarget);
    targeter.currentTarget = targeter.mainTarget;
    return validTarget;
  }

  public override void PassiveCast(TargetAbility ability)
  {
    ability.ApplyEffects(gameObject);
    if (ability.prefab) Instantiate(ability.prefab, transform);
  }

  public override IEnumerator TargetCast(TargetAbility ability, bool selfCast = false)
  {
    GameObject target = selfCast ? gameObject : targeter.currentTarget;    
    CoroutineWithResponse cwr = new CoroutineWithResponse(this, Windup(ability));
    yield return cwr.coroutine;
    if (!(bool) cwr.result) yield break;
    ability.ApplyEffects(target);
    ability.ApplyCooldown();
    if (ability.prefab)
    {
      float yPos = 0f;
      switch (ability.instantiationSettings.InstantiationPosition)
      {
        case TargetInstantiationPosition.TargetFeet: yPos = 0f; break;
        case TargetInstantiationPosition.TargetCenter: yPos = damageController.model.bounds.center.y; break;
        case TargetInstantiationPosition.TargetHead: yPos = damageController.model.bounds.max.y; break;
        default: break;
      }
      Instantiate(ability.prefab, target.transform.position.With(y: yPos), Quaternion.identity);
    }
    yield return Recovery(ability);
  }
  public override IEnumerator PointCast(PointAbility ability)
  {
    CoroutineWithResponse cwr = new CoroutineWithResponse(this, Windup(ability));
    yield return cwr.coroutine;
    if (!(bool)cwr.result) yield break;
    ability.ApplyCooldown();
    Vector3 position = targeter.currentTarget.transform.position;

    float yPos = 0f;
    switch (ability.instantiationSettings.InstantiationPosition)
    {
      case PointInstantiationPosition.Ground: yPos = 0f; break;
      default: break;
    }
    GameObject instance = Instantiate(ability.prefab, new Vector3(position.x, yPos, position.z), Quaternion.identity);
    instance.GetComponent<PointAbilityInstance>().ApplyEffects(ability);
    yield return Recovery(ability);
  }
  public override IEnumerator DirectionCast(DirectionAbility ability)
  {
    CoroutineWithResponse cwr = new CoroutineWithResponse(this, Windup(ability));
    yield return cwr.coroutine;
    if (!(bool) cwr.result) yield break;


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
    instance.layer = targeter.GetSpawnLayer();
    instance.GetComponent<AbilityProjectile>().ability = ability;
    if (ability.transferEffectsToPrefab) instance.GetComponent<AbilityProjectile>().effects = ability.effects;
    ability.ApplyCooldown();
    yield return Recovery(ability);
  }
  public IEnumerator Windup(Ability ability)
  {
    blockerController.AddBlocker(ability.blocker);
    motor.turnTowardsTarget = targeter.currentTarget;
    float castTime = ability.castTime;
    animator.SetTrigger(ability.animationTrigger.ToString());
    ActivateEffect(ability.startEffect, ability.castTime);
    while (castTime > 0)
    {
      castTime -= 0.5f;
      yield return new WaitForSeconds(Mathf.Min(castTime, 0.5f));
      if (ability.Test(targeter.currentTarget)) continue;
      // Check for interrupts
      // Should also be interruptable from outside (other character stunning caster or something)
      motor.turnTowardsTarget = null;
      blockerController.RemoveBlocker(ability.blocker);
      animator.SetTrigger("InterruptCast");
      yield return false;
      yield break;
    }
    yield return true;
  }
  public IEnumerator Recovery(Ability ability)
  {
    float timeLeft = Mathf.Max(aIAnimationUpdater.AnimationTimeLeft(), 1f);
    ActivateEffect(ability.onCastEffect);
    yield return new WaitForSeconds(timeLeft);
    motor.turnTowardsTarget = null;
    blockerController.RemoveBlocker(ability.blocker);
  }

  // Move this to ParticleManager with pooling e.t.c.
  void ActivateEffect(ParticleSystem effect, float time = -1f)
  {
    if (!effect) return;
    ParticleSystem onCastEffect = Instantiate(effect, effectsHolder);
    onCastEffect.Play();
    Destroy(onCastEffect.gameObject, time > 0 ? time : onCastEffect.main.duration + onCastEffect.main.startLifetime.constantMax);
  }
}