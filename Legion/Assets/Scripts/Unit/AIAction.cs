using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AIAction : MonoBehaviour
{
  public float attackPower = 1f;

  [Tooltip("The action which will base the nav mesh agents stopping distance")]
  [SerializeField] UnitAction mainAttack;

  [SerializeField] List<UnitAction> inputActions;
  List<UnitAction> allActions = new List<UnitAction>();
  List<UnitAction> hostileTargetActions = new List<UnitAction>();
  List<UnitAction> friendlyTargetActions = new List<UnitAction>();

  Stats stats;

  float hostileScanRange;
  LayerMask enemyLayerMask;

  float lastAttack = 8f;
  float lastAttackBuffer = 4f;
  float lastAttackTry = 0f;

  float lastHostileScan = 0f;
  float lastHostileScanBuffer = 1f;

  bool isBlocked { get { return false; } }
  bool requireNewTarget { get { return Time.time > lastAttack || (stats.currentTarget == null && Time.time > lastHostileScan); } }
  bool actionIsValid
  {
    get
    {
      float distanceToTarget = Vector3.Distance(stats.currentTarget.transform.position, transform.position);
      if (currentAction.range >= distanceToTarget) return true;
      return false;
    }
  }

  bool isPerforming;
  UnitAction currentAction;

  void Start()
  {
    stats = GetComponent<Stats>();
    stats.SetStoppingDistance(mainAttack.range);
    

    allActions.Add(Instantiate(mainAttack));
    foreach (UnitAction action in inputActions) allActions.Add(Instantiate(action));
    hostileTargetActions.AddRange(allActions.FindAll(x => x.targetType == TargetType.Hostile));
    friendlyTargetActions.AddRange(allActions.FindAll(x => x.targetType == TargetType.Friendly));

    hostileScanRange = Mathf.Clamp(hostileTargetActions.Max(x => x.scanRange), 15, 100);
    enemyLayerMask = 1 << stats.teamData.enemyLayer;
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
        GameObject target = FindNewTarget();
        stats.SetNewTarget(target);
      }
      else if (stats.currentTarget) StartAction();
    }
  }

  public void ForceNewTarget()
  {
    Debug.Log("ForceNewTarget");
    stats.ClearTarget();
    GameObject target = FindNewTarget();
    stats.SetNewTarget(target);
  }

  void StartAction()
  {
    List<UnitAction> availableActions = allActions.FindAll(x => !x.onCooldown);
    if (availableActions.Count == 0) return;

    float distanceToTarget = Vector3.Distance(stats.currentTarget.transform.position, transform.position);
    UnitAction action = availableActions.Find(x => x.range >= distanceToTarget);
    if (action == null) return;

    Debug.Log("AIAction: Found action, will start performing " + action.name);
    isPerforming = true;
    currentAction = action;
    action.StartPerform();
  }

  void PerformAction()
  {
    lastAttack = Time.time + mainAttack.cooldown + lastAttackBuffer;
    currentAction.Perform(stats.currentTarget, gameObject);
    ClearAction();
  }

  void ClearAction()
  {
    isPerforming = false;
    currentAction = null;
  }

  GameObject FindNewTarget()
  {

    lastHostileScan = Time.time + lastHostileScanBuffer;
    lastAttack = Time.time + mainAttack.cooldown + lastAttackBuffer;
    Debug.Log("lastAttack: " + lastAttack);

    Collider[] colliders = FindTargets(enemyLayerMask, hostileScanRange, transform.position);
    if (colliders.Length > 0)
    {
      if (stats.currentTarget && colliders.Length > 1 && colliders[0].gameObject == stats.currentTarget) return colliders[1].gameObject;
      return colliders[0].gameObject;
    }
    return null;
  }

  Collider[] FindTargets(LayerMask layerMask, float maxRange, Vector3 position)
  {
    Collider[] colliders = Physics.OverlapSphere(position, maxRange, layerMask);
    return colliders
      .Where(x => x.GetComponent<Damageable>())
      .OrderBy(x => (x.transform.position - position).sqrMagnitude)
      .ToArray();
  }


}
