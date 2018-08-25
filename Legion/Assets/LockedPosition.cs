using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedPosition : MonoBehaviour
{
  AIStateController controller;
  Animator animator;

  void Start()
  {
    controller = GetComponent<AIStateController>();
    animator = GetComponent<Animator>();
    controller.enabled = false;
    animator.SetBool("Locked", true);
  }

  void OnDestroy()
  {
    controller.enabled = true;
    if (animator.isActiveAndEnabled) animator.SetBool("Locked", false);
  }
}
