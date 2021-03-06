﻿using UnityEngine;
using UnityEngine.AI;

public class LockedPosition : MonoBehaviour
{
  AIStateController controller;
  Animator animator;
  NavMeshAgent navMeshAgent;

  void Start()
  {
    controller = GetComponent<AIStateController>();
    animator = GetComponent<Animator>();
    navMeshAgent = GetComponent<NavMeshAgent>();
    navMeshAgent.enabled = false;
    controller.enabled = false;
    animator.SetBool("Locked", true);
    GameManager.ReleaseUnits += Release;
  }

  void Release()
  {
    Destroy(this);
  }

  void OnDestroy()
  {
    navMeshAgent.enabled = true;
    controller.enabled = true;
    if (animator.isActiveAndEnabled) animator.SetBool("Locked", false);
  }
}
