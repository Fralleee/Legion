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
  LayerMask layerMask;

  bool isBlocked { get { return blockerController.ContainsBlocker(movement: true); } }

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    statisticsController = GetComponent<StatisticsController>();
    blockerController = GetComponent<BlockerController>();
    layerMask = 1 << LayerMask.NameToLayer("Environment");
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
    if (agent.remainingDistance <= agent.stoppingDistance)
    {
      Ray ray = new Ray(transform.position, target - transform.position);
      if (Physics.Raycast(ray, agent.remainingDistance, layerMask)) agent.stoppingDistance = 0f;
    }
  }

}
