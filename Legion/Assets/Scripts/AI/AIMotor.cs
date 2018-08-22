using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AIMotor : MonoBehaviour
{
  public float travelSpeed = 4f;
  public float chasingSpeed = 6f;
  public float wanderTimer = 5f;
  public bool isBlocked { get { return blockerController.ContainsBlocker(movement: true); } }
  public bool isRotationBlocked { get { return blockerController.ContainsBlocker(rotation: true); } }
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

  public void SetStoppingDistance(float distance)
  {
    navMeshAgent.stoppingDistance = distance;
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

  IEnumerator ActivateAgent(float delay)
  {
    isRunningCoroutine = true;
    navMeshObstacle.enabled = false;
    yield return new WaitForSeconds(delay);
    navMeshAgent.enabled = true;
    isRunningCoroutine = false;
  }
}