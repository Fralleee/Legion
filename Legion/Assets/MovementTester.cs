﻿using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementTester : MonoBehaviour
{
  [SerializeField] Transform target;
  BlockerController blockerController;
  NavMeshAgent navMeshAgent;
  NavMeshObstacle navMeshObstacle;
  NavMeshPath navMeshPath;
  bool isRunningCoroutine;
  public bool IsBlocked { get { return blockerController ? blockerController.ContainsBlocker(abilities: true) : false; } }

  void Start()
  {
    blockerController = GetComponent<BlockerController>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshObstacle = GetComponent<NavMeshObstacle>();
    navMeshPath = new NavMeshPath();
  }
  void Update()
  {    
    if (IsBlocked || Vector3.Distance(transform.position, target.position) <= navMeshAgent.stoppingDistance + 0.5f)
    {
      if (navMeshAgent.enabled)
      {
        if (isRunningCoroutine)
        {
          StopCoroutine(ActivateAgent(0.25f));
          isRunningCoroutine = false;
        }
        navMeshAgent.enabled = false;
        navMeshObstacle.enabled = true;
      }
      transform.LookAtFlat(target);
    }
    else if (!isRunningCoroutine && navMeshObstacle.enabled)
    {
      StartCoroutine(ActivateAgent(0.25f));
    }
    else if (navMeshAgent.enabled)
    {
      if (target && CalculateNewPath())
      {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(target.position);
      }
      else navMeshAgent.isStopped = true;
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

  bool CalculateNewPath()
  {
    navMeshAgent.CalculatePath(target.position, navMeshPath);
    return navMeshPath.status == NavMeshPathStatus.PathComplete;
  }
}