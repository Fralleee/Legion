using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BlockerController))]
[RequireComponent(typeof(AITargeter))]
public class AIAbilityController : MonoBehaviour
{
  [Tooltip("The action which will base the nav mesh agents stopping distance")]
  [SerializeField] Ability mainAttack;
  [SerializeField] List<Ability> inputAbilities;
  List<Ability> allAbilities = new List<Ability>();
  List<Ability> hostileTargetAbilities = new List<Ability>();
  List<Ability> friendlyTargetAbilities = new List<Ability>();

  BlockerController blockerController;
  AITargeter targeter;

  bool isBlocked { get { return blockerController.ContainsBlocker(actions: true); } }
  bool targetInRange
  {
    get
    {
      if (targeter.currentTarget) return IsTargetInRange(targeter.currentTarget, currentAbility.range);
      return false;
    }
  }
  bool isCasting;
  Ability currentAbility;

  void Start()
  {
    if (!mainAttack) Debug.LogWarning(gameObject.name + " is missing a mainAttack.");
    if (!mainAttack.requireLineOfSight) Debug.LogWarning(gameObject.name + "'s mainAttack (" + mainAttack.name + ") does not require Line of Sight, this could cause issues.");

    blockerController = GetComponent<BlockerController>();
    targeter = GetComponent<AITargeter>();
    targeter.SetBaseStoppingDistance(mainAttack.range - 1f);

    allAbilities.Add(Instantiate(mainAttack));
    foreach (Ability ability in inputAbilities) allAbilities.Add(Instantiate(ability));
    foreach (Ability ability in allAbilities) ability.SetupAbility(gameObject);
    hostileTargetAbilities.AddRange(allAbilities.FindAll(x => x.targetType == TargetType.Hostile));
    friendlyTargetAbilities.AddRange(allAbilities.FindAll(x => x.targetType == TargetType.Friendly));
    targeter.SetHostileScanRange(hostileTargetAbilities.Max(x => x.scanRange));
  }

  void Update()
  {
    if (isCasting && currentAbility)
    {
      if (!targetInRange) ClearAbility();
      else if (currentAbility.readyToCast) Cast();
    }
    else if (!isBlocked && targeter.currentTarget) PrepareCast();
  }

  void PrepareCast()
  {
    List<Ability> availableAbilities = allAbilities.FindAll(x => !x.onCooldown);
    if (availableAbilities.Count == 0) return;
    availableAbilities = availableAbilities.FindAll(x => IsTargetInRange(targeter.currentTarget, x.range));
    if (availableAbilities.Count == 0) return;

    foreach (Ability ability in availableAbilities)
    {
      if (ability.TryCast(targeter.currentTarget))
      {
        isCasting = true;
        currentAbility = ability;
        ability.PrepareCast();
      }
    }
  }

  void Cast()
  {
    targeter.SetLastInteractionWithTarget(mainAttack.cooldown);
    currentAbility.Perform(targeter.currentTarget);
    ClearAbility();
  }

  void ClearAbility()
  {
    isCasting = false;
    currentAbility.Interrupt();
    currentAbility = null;    
  }

  bool IsTargetInRange(GameObject target, float checkRange)
  {
    float distanceToTarget = Vector3.Distance(target.transform.position, transform.position) - targeter.targetWidth;
    return checkRange >= distanceToTarget;
  }
}
