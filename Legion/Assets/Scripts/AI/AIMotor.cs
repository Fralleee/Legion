using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AIMotor : MonoBehaviour, IMotor
{
  public float travelSpeed = 4f;
  public float chasingSpeed = 6f;
  public float wanderTimer;
  float speedModifier = 1f;
  bool isBlocked { get { return blockerController && blockerController.Movement; } }
  bool isRotationBlocked { get { return blockerController && blockerController.Rotation; } }
  public Transform turnTowardsTarget;
  BlockerController blockerController;
  NavMeshAgent navMeshAgent;
  NavMeshObstacle navMeshObstacle;
  IEnumerator coroutine;
  bool isRunningCoroutine;

  void Awake()
  {
    blockerController = GetComponent<BlockerController>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshObstacle = GetComponent<NavMeshObstacle>();
    coroutine = ActivateAgent(0.25f);
  }

  void Update()
  {
    if (turnTowardsTarget && !isRotationBlocked) transform.LookAt(turnTowardsTarget);
  }

  public void SetStoppingDistance(float distance)
  {
    navMeshAgent.stoppingDistance = distance;
  }

  public void TryMove(Transform target, bool chasing = false)
  {
    if (isBlocked) Stop(target);
    else Move(target, chasing);
  }

  public void Move(Transform target, bool chasing = false)
  {
    if (!target) return;
    if (!isRunningCoroutine && navMeshObstacle.enabled)
    {
      coroutine = ActivateAgent(0.25f);
      StartCoroutine(coroutine);
    }
    else if (navMeshAgent.enabled)
    {
      navMeshAgent.isStopped = false;
      navMeshAgent.speed = chasing ? chasingSpeed : travelSpeed;
      navMeshAgent.speed *= speedModifier;
      navMeshAgent.SetDestination(target.position);
    }
  }

  public void Stop(Transform target)
  {
    if (navMeshAgent.enabled)
    {
      navMeshAgent.isStopped = true;
      if (isRunningCoroutine)
      {
        StopCoroutine(coroutine);
        isRunningCoroutine = false;
      }
      navMeshAgent.enabled = false;
      navMeshObstacle.enabled = true;
    }
    if (target) transform.LookAt(target.transform);
  }

  public void SimpleMove(Vector3 position)
  {
    if (navMeshAgent.enabled) navMeshAgent.SetDestination(position);
  }

  public void ApplyModifier(float value)
  {
    speedModifier += value;
  }

  IEnumerator ActivateAgent(float delay)
  {
    isRunningCoroutine = true;
    navMeshObstacle.enabled = false;
    yield return new WaitForSeconds(delay);
    navMeshAgent.enabled = true;
    isRunningCoroutine = false;
  }
}