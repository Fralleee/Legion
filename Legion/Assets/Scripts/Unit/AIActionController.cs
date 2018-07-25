using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BlockerController))]
[RequireComponent(typeof(StatisticsController))]
public class AIActionController : MonoBehaviour
{
  [SerializeField] AITargetingSettings targetingSettings;
  [Tooltip("The action which will base the nav mesh agents stopping distance")]
  [SerializeField] UnitAction mainAttack;
  [SerializeField] List<UnitAction> inputActions;
  List<UnitAction> allActions = new List<UnitAction>();
  List<UnitAction> hostileTargetActions = new List<UnitAction>();
  List<UnitAction> friendlyTargetActions = new List<UnitAction>();

  StatisticsController statisticsController;
  BlockerController blockerController;



  bool isBlocked { get { return blockerController.ContainsBlocker(actions: true); } }
  bool requireNewTarget { get { return Time.time > targetingSettings.lastAttack || (statisticsController.targetStats.currentTarget == null && Time.time > targetingSettings.lastHostileScan); } }
  bool actionIsValid
  {
    get
    {
      float distanceToTarget = Vector3.Distance(statisticsController.targetStats.currentTarget.transform.position, transform.position);
      if (currentAction.range >= distanceToTarget) return true;
      return false;
    }
  }

  bool isPerforming;
  UnitAction currentAction;

  void Start()
  {
    if (!mainAttack.requireLineOfSight) Debug.LogWarning(gameObject.name + "'s mainAttack (" + mainAttack.name + ") does not require Line of Sight, this could cause issues.");

    blockerController = GetComponent<BlockerController>();
    statisticsController = GetComponent<StatisticsController>();
    statisticsController.SetStoppingDistance(mainAttack.range);

    targetingSettings = Instantiate(targetingSettings);
    allActions.Add(Instantiate(mainAttack));
    foreach (UnitAction action in inputActions) allActions.Add(Instantiate(action));
    foreach (UnitAction action in allActions) action.SetupAction(gameObject);
    hostileTargetActions.AddRange(allActions.FindAll(x => x.targetType == TargetType.Hostile));
    friendlyTargetActions.AddRange(allActions.FindAll(x => x.targetType == TargetType.Friendly));

    targetingSettings.SetHostileScanRange(hostileTargetActions.Max(x => x.scanRange));
    targetingSettings.enemyLayerMask = 1 << statisticsController.teamData.enemyLayer;
  }

  void Update()
  {
    if (isPerforming && currentAction)
    {
      if (!actionIsValid) ClearAction();
      else if (currentAction.readyToPerform) PerformAction();
    }
    else if (!isBlocked)
    {
      if (requireNewTarget)
      {
        GameObject target = LookForTargetInRange();
        statisticsController.SetTarget(target);
      }
      else if (statisticsController.targetStats.currentTarget) StartAction();
    }
  }

  void StartAction()
  {
    List<UnitAction> availableActions = allActions.FindAll(x => !x.onCooldown);
    if (availableActions.Count == 0) return;

    float distanceToTarget = Vector3.Distance(statisticsController.targetStats.currentTarget.transform.position, transform.position);
    List<UnitAction> actions = availableActions.FindAll(x => x.range >= distanceToTarget);
    if (actions.Count == 0) return;

    foreach (UnitAction action in actions)
    {
      if(action.TryPerform(statisticsController.targetStats.currentTarget))
      {
        isPerforming = true;
        currentAction = action;
        action.StartPerform();
      }
    }
  }

  void PerformAction()
  {
    targetingSettings.SetLastAttack(mainAttack);
    currentAction.Perform(statisticsController.targetStats.currentTarget);
    ClearAction();
  }

  void ClearAction()
  {
    isPerforming = false;
    currentAction = null;
  }


  // Target stuff (AI Only)
  public void TargetDied()
  {
    statisticsController.ClearTarget();
    GameObject target = LookForTargetInRange();
    statisticsController.SetTarget(target);
  }

  GameObject LookForTargetInRange()
  {
    targetingSettings.SetLastHostileScan();
    targetingSettings.SetLastAttack(mainAttack);
    Collider[] colliders = TargetFinder.FindTargetsWithDamageable(targetingSettings.enemyLayerMask, targetingSettings.hostileScanRange, transform.position);
    if (colliders.Length > 0)
    {
      if (statisticsController.targetStats.currentTarget && colliders.Length > 1 && colliders[0].gameObject == statisticsController.targetStats.currentTarget) return colliders[1].gameObject;
      return colliders[0].gameObject;
    }
    return null;
  }

}
