using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMotor : BlockerBehaviour
{
  NavMeshAgent agent;
  Stats stats;

  bool isBlocked
  {
    get { return blockerList.blockers.Exists(x => x.Movement); }
  }

  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
    stats = GetComponent<Stats>();
  }

  void Update()
  {
    if (isBlocked) agent.isStopped = true;
    else if (stats.currentTarget)
    {
      agent.SetDestination(stats.currentTarget.transform.position);
      agent.stoppingDistance = stats.stoppingDistance;
    }
    else if (stats.mainObjective)
    {
      agent.SetDestination(stats.mainObjective.transform.position);
      agent.stoppingDistance = stats.stoppingDistance;
    }
  }
}
