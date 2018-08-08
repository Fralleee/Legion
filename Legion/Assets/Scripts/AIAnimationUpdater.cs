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
    Vector3 movement = transform.TransformDirection(navMeshAgent.velocity);
    animator.SetFloat("Vertical", Mathf.Abs(movement.x), .1f, Time.deltaTime);
    animator.SetFloat("Horizontal", Mathf.Abs(movement.z), .1f, Time.deltaTime);
  }
}
