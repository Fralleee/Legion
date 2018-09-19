using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodySyncronizer : MonoBehaviour
{
  new Rigidbody rigidbody;
  Animator animator;

  void Start()
  {
    rigidbody = GetComponent<Rigidbody>();
    animator = GetComponent<Animator>();
  }

  void Update()
  {
    if (rigidbody.velocity.magnitude > 0) animator.applyRootMotion = false;
    else animator.applyRootMotion = true;
  }
}
