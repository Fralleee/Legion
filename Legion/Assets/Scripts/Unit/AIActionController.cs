using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BlockerController))]
[RequireComponent(typeof(AITargeter))]
public class AIActionController : MonoBehaviour
{
  [Tooltip("The action which will base the nav mesh agents stopping distance")]
  [SerializeField] UnitAction mainAttack;
  [SerializeField] List<UnitAction> inputActions;
  List<UnitAction> allActions = new List<UnitAction>();
  List<UnitAction> hostileTargetActions = new List<UnitAction>();
  List<UnitAction> friendlyTargetActions = new List<UnitAction>();

  BlockerController blockerController;
  AITargeter targeter;

  bool isBlocked { get { return blockerController.ContainsBlocker(actions: true); } }
  bool actionIsValid
  {
    get
    {
      if (targeter.currentTarget)
      {
        float distanceToTarget = Vector3.Distance(targeter.currentTarget.transform.position, transform.position);
        if (currentAction.range >= distanceToTarget) return true;
      }
      return false;
    }
  }
  bool isPerforming;
  UnitAction currentAction;

  void Start()
  {
    if (!mainAttack.requireLineOfSight) Debug.LogWarning(gameObject.name + "'s mainAttack (" + mainAttack.name + ") does not require Line of Sight, this could cause issues.");

    blockerController = GetComponent<BlockerController>();
    targeter = GetComponent<AITargeter>();
    targeter.SetStoppingDistance(mainAttack.range - 0.5f);

    allActions.Add(Instantiate(mainAttack));
    foreach (UnitAction action in inputActions) allActions.Add(Instantiate(action));
    foreach (UnitAction action in allActions) action.SetupAction(gameObject);
    hostileTargetActions.AddRange(allActions.FindAll(x => x.targetType == TargetType.Hostile));
    friendlyTargetActions.AddRange(allActions.FindAll(x => x.targetType == TargetType.Friendly));
    targeter.SetHostileScanRange(hostileTargetActions.Max(x => x.scanRange));
  }

  void Update()
  {
    if (isPerforming && currentAction)
    {
      if (!actionIsValid) ClearAction();
      else if (currentAction.readyToPerform) PerformAction();
    }
    else if (!isBlocked && targeter.currentTarget) StartAction();
  }

  void StartAction()
  {
    List<UnitAction> availableActions = allActions.FindAll(x => !x.onCooldown);
    if (availableActions.Count == 0) return;

    float distanceToTarget = Vector3.Distance(targeter.currentTarget.transform.position, transform.position);
    List<UnitAction> actions = availableActions.FindAll(x => x.range >= distanceToTarget);
    if (actions.Count == 0) return;

    foreach (UnitAction action in actions)
    {
      if (action.TryPerform(targeter.currentTarget))
      {
        isPerforming = true;
        currentAction = action;
        action.StartPerform();
      }
    }
  }

  void PerformAction()
  {
    targeter.SetLastInteractionWithTarget(mainAttack.cooldown);
    currentAction.Perform(targeter.currentTarget);
    ClearAction();
  }

  void ClearAction()
  {
    isPerforming = false;
    currentAction = null;
  }

}
