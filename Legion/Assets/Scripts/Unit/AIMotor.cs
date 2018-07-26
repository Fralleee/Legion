using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BlockerController))]
[RequireComponent(typeof(StatisticsController))]
[RequireComponent(typeof(AITargeter))]
public class AIMotor : MonoBehaviour
{
  NavMeshAgent agent;
  StatisticsController statisticsController;
  BlockerController blockerController;
  AITargeter targeter;

  bool isBlocked { get { return blockerController.ContainsBlocker(movement: true); } }

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    statisticsController = GetComponent<StatisticsController>();
    blockerController = GetComponent<BlockerController>();
    targeter = GetComponent<AITargeter>();
  }

  void Update()
  {
    if (isBlocked) agent.isStopped = true;
    else if (needsToMove()) Move();
    else StopAndTurn();
  }

  bool needsToMove()
  {
    GameObject target = statisticsController.movementTarget;
    if (target == null) return false;

    agent.stoppingDistance = targeter.hasLineOfSight ? statisticsController.targetStats.stoppingDistance : -1f;
    return !targeter.hasLineOfSight;
  }

  void Move()
  {
    agent.isStopped = false;
    agent.SetDestination(statisticsController.movementTarget.transform.position);
  }

  void StopAndTurn()
  {
    agent.isStopped = true;
    if (statisticsController.movementTarget && agent.velocity.magnitude < 3)
    {
      Vector3 direction = statisticsController.movementTarget.transform.position - transform.position;
      Quaternion toRotation = Quaternion.LookRotation(direction);
      transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.2f);
    }
  }

}
