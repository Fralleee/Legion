//using UnityEngine;

//[RequireComponent(typeof(StatisticsController))]
//public class AITargeter : MonoBehaviour, ITarget
//{
//  [SerializeField] float targetSwitchEvaluationTime = 4f;
//  [SerializeField] float targetScanCooldown = 10f;
//  [SerializeField] float lineOfSightCheckCooldown = 0.25f;
//  [Range(15, 100)] [SerializeField] float hostileScanRange = 15f;

//  public GameObject _currentTarget;
//  public GameObject currentTarget { get; private set; }
//  public GameObject objective { get; private set; }
//  public GameObject target { get { return currentTarget ? currentTarget : objective; } }
//  public float targetWidth = 0f;
//  float baseStoppingDistance = 2f;
//  public float stoppingDistance { get; private set; }
//  public bool hasLineOfSight { get; set; }
//  public float lastInteractionWithTarget { get; private set; }
//  public float lastHostileScan { get; private set; }

//  StatisticsController statisticsController;
//  int environmentLayer;
//  LayerMask environmentLayerMask;
//  LayerMask enemyLayerMask;
//  float lastLineOfSightCheck;
//  bool requireNewTarget
//  {
//    get
//    {
//      return Time.time > lastInteractionWithTarget || (currentTarget == null && Time.time > lastHostileScan);
//    }
//  }

//  void Start()
//  {
//    statisticsController = GetComponent<StatisticsController>();
//    environmentLayer = LayerMask.NameToLayer("Environment");
//    enemyLayerMask = 1 << statisticsController.teamData.enemyLayer;
//    environmentLayerMask = 1 << environmentLayer;
//  }
//  void Update()
//  {
//    //if(target) Debug.Log(name + " has target " + target.name);
//    //else Debug.LogWarning(name + " has no target");

//    if (requireNewTarget)
//    {
//      GameObject target = LookForTargetInRange();
//      if (target)
//      {
//        SetTarget(target);
//        CheckLineOfSight();
//      }
//    }
//    else if (Time.time > lastLineOfSightCheck && target) CheckLineOfSight();
//  }
//  GameObject LookForTargetInRange()
//  {
//    SetLastHostileScan();
//    SetLastInteractionWithTarget();
//    Collider[] colliders = TargetFinder.FindTargetsWithDamageable(enemyLayerMask, hostileScanRange, transform.position);
//    foreach (Collider collider in colliders)
//    {
//      RaycastHit hit;
//      if (TargetFinder.HasLineOfSight(gameObject, collider.gameObject, out hit, hostileScanRange, environmentLayerMask | enemyLayerMask))
//      {
//        if (hit.transform.gameObject.layer == statisticsController.teamData.enemyLayer) return collider.gameObject;
//      }
//    }
//    return null;
//  }
//  public void SetBaseStoppingDistance(float distance) { baseStoppingDistance = distance; }
//  public void SetStoppingDistance(float distance) { stoppingDistance = distance; }
//  public void SetLastInteractionWithTarget(float extraTime = 0) { lastInteractionWithTarget = Time.time + extraTime + targetSwitchEvaluationTime; }
//  public void SetHostileScanRange(float maxRangeInActions) { hostileScanRange = Mathf.Clamp(Mathf.Max(hostileScanRange, maxRangeInActions), 15, 100); }
//  public void SetLastHostileScan() { lastHostileScan = Time.time + targetScanCooldown; }
//  public void ClearDeadTarget(GameObject target = null)
//  {
//    if (target == currentTarget) currentTarget = null;
//    else if (target == objective) objective = null;
//    hasLineOfSight = false;
//    return;
//  }
//  public void SetObjective(GameObject target)
//  {
//    Debug.Log("NEW OBJECTIVE: " + target.gameObject.name);
//    objective = target;
//  }
//  public void SetTarget(GameObject target)
//  {
//    targetWidth = target.GetComponent<Collider>().bounds.size.x / 2;
//    Debug.Log("NEW TARGET: " + target.gameObject.name);
//    SetStoppingDistance(baseStoppingDistance + targetWidth);
//    currentTarget = target;
//    _currentTarget = target;
//  }
//  public void CheckLineOfSight()
//  {
//    lastLineOfSightCheck = Time.time + lineOfSightCheckCooldown;
//    if (Vector3.Distance(transform.position, target.transform.position) <= stoppingDistance)
//    {
//      RaycastHit hit;
//      if (TargetFinder.HasLineOfSightRadius(gameObject, target, out hit, stoppingDistance, 0.5f, environmentLayerMask | enemyLayerMask))
//      {
//        hasLineOfSight = hit.transform.gameObject.layer != environmentLayer;
//        return;
//      }
//    }
//    hasLineOfSight = false;
//  }
//}
