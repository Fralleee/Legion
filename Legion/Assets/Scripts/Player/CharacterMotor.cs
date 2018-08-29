using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{
  [Header("Motor Settings")]
  public bool useGravity = true;
  public float speed = 1f;
  public float fallMultiplier = 2.5f;
  public float jumpPower = 50f;
  [HideInInspector] public CharacterController controller;

  Vector3 movement;
  float vSpeed = 0;

  BlockerController blockerController;

  public bool isBlocked { get { return blockerController.ContainsBlocker(movement: true); } }

  void Start()
  {
    controller = GetComponent<CharacterController>();
    blockerController = GetComponent<BlockerController>();
  }

  void Update()
  {
    if (isBlocked)
    {
      movement = Vector3.zero;
      if (useGravity)
      {
        vSpeed += Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        movement.y = vSpeed;
        controller.Move(movement * Time.deltaTime);
      }
      return;
    }
    float movementVertical = Input.GetAxisRaw("Vertical");
    float movementHorizontal = Input.GetAxisRaw("Horizontal");
    float movementMultiplier = movementVertical < 0 ? 0.5f : 1;

    movement = new Vector3(movementHorizontal, 0, movementVertical) * movementMultiplier;
    movement = transform.TransformDirection(movement);
    movement *= speed;

    if (controller.isGrounded)
    {
      vSpeed = -1;
      if (Input.GetButtonDown("Jump")) vSpeed = jumpPower;
    }

    if (useGravity) vSpeed += Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
    movement.y = vSpeed;
    controller.Move(movement * Time.deltaTime);
  }

}
