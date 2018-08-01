using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

//[RequireComponent(typeof(NavMeshAgent))]
//[RequireComponent(typeof(BlockerController))]
//[RequireComponent(typeof(AITargeter))]
public class AIMotor : MonoBehaviour
{
  //[SerializeField] Blocker spawnBlocker;
  //[SerializeField] float movementSpeed = 4f;
  //[SerializeField] float chasingSpeed = 6f;
  //NavMeshAgent agent;
  //BlockerController blockerController;

  //AITargeter targeter;

  //bool isBlocked { get { return blockerController.ContainsBlocker(movement: true); } }
  //bool needsToMove
  //{
  //  get
  //  {
  //    GameObject target = targeter.target;
  //    if (target == null) return false;

  //    agent.stoppingDistance = targeter.hasLineOfSight ? targeter.stoppingDistance : -1f;
  //    return !targeter.hasLineOfSight;
  //  }
  //}

  void Start()
  {
    //agent = GetComponent<NavMeshAgent>();
    //blockerController = GetComponent<BlockerController>();
    //blockerController.AddBlocker(spawnBlocker);
    //targeter = GetComponent<AITargeter>();
  }

  //void Update()
  //{
  //  if (isBlocked) agent.isStopped = true;
  //  else if (needsToMove) Move();
  //  else StopAndTurn();
  //}

  //void Move()
  //{
  //  agent.isStopped = false;
  //  agent.SetDestination(targeter.target.transform.position);
  //}

  //void StopAndTurn()
  //{
  //  agent.isStopped = true;
  //  if (targeter.target && agent.velocity.magnitude < 3)
  //  {
  //    Vector3 direction = targeter.target.transform.position - transform.position;
  //    Quaternion toRotation = Quaternion.LookRotation(direction);
  //    transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, 0.2f);
  //  }
  //}
}
