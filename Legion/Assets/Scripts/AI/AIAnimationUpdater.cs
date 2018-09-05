using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIAnimationUpdater : MonoBehaviour
{
  NavMeshAgent navMeshAgent;
  Animator animator;

  void Start()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
    animator = GetComponentInChildren<Animator>();
  }

  void Update()
  {
    if (navMeshAgent) animator.SetFloat("Vertical", navMeshAgent.velocity.magnitude, .1f, Time.deltaTime);
  }
}
