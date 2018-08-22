using Fralle;
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
  NavMeshPath navMeshPath;
  IEnumerator coroutine;
  bool isRunningCoroutine;

  void Awake()
  {
    blockerController = GetComponent<BlockerController>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshObstacle = GetComponent<NavMeshObstacle>();
    navMeshPath = new NavMeshPath();
    coroutine = ActivateAgent(0.25f);
  }

  public void SetStoppingDistance(float distance)
  {
    navMeshAgent.stoppingDistance = distance;
  }

  public void Move(Transform target, bool chasing = false)
  {
    if (!target || isBlocked || Vector3.Distance(transform.position, target.position) <= navMeshAgent.stoppingDistance)
    {
      Stop();
    }
    else if (!isRunningCoroutine && navMeshObstacle.enabled)
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

  void Stop()
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
  }

  public void SimpleMove(Vector3 position)
  {
    if (navMeshAgent.enabled)
    {
      navMeshAgent.SetDestination(position);
    }
  }


  IEnumerator ActivateAgent(float delay)
  {
    isRunningCoroutine = true;
    navMeshObstacle.enabled = false;
    yield return new WaitForSeconds(delay);
    navMeshAgent.enabled = true;
    isRunningCoroutine = false;
  }

  bool CalculateNewPath(Vector3 position)
  {
    navMeshAgent.CalculatePath(position, navMeshPath);
    return navMeshPath.status == NavMeshPathStatus.PathComplete;
  }

}