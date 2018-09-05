using UnityEngine;

public class CharacterAnimations : MonoBehaviour
{
  CharacterController controller;
  CharacterMotor motor;
  Animator animator;

  void Start()
  {
    controller = GetComponent<CharacterController>();
    motor = GetComponent<CharacterMotor>();
    animator = GetComponentInChildren<Animator>();
  }

  void Update()
  {
    Vector3 transformedVelocity = motor.isBlocked || !motor.enabled ? Vector3.zero : transform.InverseTransformDirection(controller.velocity);
    animator.SetFloat("Vertical", transformedVelocity.z, .1f, Time.deltaTime);
    animator.SetFloat("Horizontal", transformedVelocity.x, .1f, Time.deltaTime);
    animator.SetBool("Grounded", controller.isGrounded);
  }
}
