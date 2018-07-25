using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BlockerController))]
[RequireComponent(typeof(StatisticsController))]
public class AIMotor : MonoBehaviour
{
  NavMeshAgent agent;
  StatisticsController statisticsController;
  BlockerController blockerController;

  bool isBlocked { get { return blockerController.ContainsBlocker(movement: true); } }

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    statisticsController = GetComponent<StatisticsController>();
    blockerController = GetComponent<BlockerController>();
  }

  void Update()
  {
    if (isBlocked) agent.isStopped = true;
    else if (statisticsController.targetStats.currentTarget) MoveTowards(statisticsController.targetStats.currentTarget.transform.position);
    else if (statisticsController.targetStats.mainObjective) MoveTowards(statisticsController.targetStats.mainObjective.transform.position);
    else agent.isStopped = true;
  }

  void MoveTowards(Vector3 target)
  {
    agent.isStopped = false;
    agent.SetDestination(target);
    agent.stoppingDistance = statisticsController.targetStats.stoppingDistance;

    // TODO:
    // If target is out of LoS then we need to alter the stopping distance and move closer

  }

}
