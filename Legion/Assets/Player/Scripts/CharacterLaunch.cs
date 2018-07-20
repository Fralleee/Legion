﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterLaunch : BlockerBehaviour
{

  StateMachine<States> fsm;
  CharacterController controller;
  CharacterMotor characterMotor;
  ImpactReceiver impactReceiver;
  Animator animator;
  CameraUtils cameraUtils;
  CameraController cameraController;
  Transform landingIndicatorInstance;
  GameObject leftHandParticles;
  GameObject rightHandParticles;
  List<ParticleSystem> launchParticles = new List<ParticleSystem>();

  [SerializeField] float castTime = 1f;
  [SerializeField] float launchForce = 25f;
  [SerializeField] FloatVariable cooldown;
  [SerializeField] Transform landingIndicatorPrefab;
  [SerializeField] GameObject landingEffectPrefab;
  [SerializeField] Transform cameraFocusAtLaunch;

  [SerializeField] StringRangeVariable progress;

  [SerializeField] ShakeTransformEventData cameraShake;

  bool CanLaunch { get { return cooldown.currentValue <= 0 && controller.isGrounded && !Physics.Raycast(transform.position, Vector3.up, 25f); } }

  void Start()
  {
    cooldown.currentValue = 0;
    controller = GetComponent<CharacterController>();
    characterMotor = GetComponent<CharacterMotor>();
    impactReceiver = GetComponent<ImpactReceiver>();
    animator = GetComponentInChildren<Animator>();
    cameraUtils = Camera.main.GetComponentInParent<CameraUtils>();
    cameraController = Camera.main.GetComponentInParent<CameraController>();
    fsm = StateMachine<States>.Initialize(this);
    fsm.ChangeState(States.Default);
    Transform[] transforms = GetComponentsInChildren<Transform>();
    foreach (Transform t in transforms)
      if (t.name == "Hand Particles")
        launchParticles.Add(t.GetComponent<ParticleSystem>());
  }

  void Update() { if (cooldown.currentValue > 0) cooldown.currentValue = Mathf.Clamp(cooldown.currentValue - Time.deltaTime, 0, cooldown.defaultValue); }


  public enum States
  {
    Default,
    NotAvailable,
    Charging,
    Launching,
    Hovering,
    Diving,
    Landing
  }
  #region State handling
  void Default_Update()
  {
    //currentCastTime.currentValue = 0f;
    if (Input.GetButtonDown("Launch") && CanLaunch && !isBlocked) fsm.ChangeState(States.Charging);
  }

  void Charging_Enter()
  {
    if (isBlocked)
    {
      fsm.ChangeState(States.Default);
      progress.value = 0f;
      return;
    }
    progress.text = "LAUNCHING!";
    progress.minValue = 0f;
    progress.maxValue = castTime;
    progress.value = 0f;
    ApplyBlocker();
    animator.SetBool("Charging Launch", true);
    ActivateLaunchParticles();
  }
  void Charging_Update()
  {
    if (isBlocked)
    {
      fsm.ChangeState(States.Default);
      progress.value = 0f;
      return;
    }
    if (Input.GetKey(KeyCode.Q) && CanLaunch) progress.value += Time.deltaTime;
    else fsm.ChangeState(States.Default);
    if (progress.value >= progress.maxValue) fsm.ChangeState(States.Launching);
  }
  void Charging_Exit()
  {
    RemoveBlocker();
    DeActivateLaunchParticles();
    progress.value = 0f;
    animator.SetBool("Charging Launch", false);
  }

  void Launching_Enter()
  {
    ApplyBlocker();
    ActivateLaunchParticles();
    cooldown.currentValue = cooldown.defaultValue;
    animator.SetTrigger("Launch");
    animator.SetBool("Airbourne", true);
  }
  void Launching_Update()
  {
    if (!impactReceiver.hasActiveImpact) fsm.ChangeState(States.Hovering);
  }

  void Hovering_Enter()
  {
    characterMotor.useGravity = false;
    cameraController.ToggleShoulderLook(cameraFocusAtLaunch);
    DeActivateLaunchParticles();
    landingIndicatorInstance = Instantiate(landingIndicatorPrefab);
  }
  void Hovering_Update()
  {
    if (Input.GetKeyDown(KeyCode.Q)) fsm.ChangeState(States.Landing);
    DrawLanding();
  }
  void Hovering_Exit()
  {
    cameraController.ToggleShoulderLook();
    animator.SetBool("Airbourne", false);
  }

  void Landing_Enter()
  {
    blocker.Camera = true;
    impactReceiver.AccelerateTo(landingIndicatorInstance.position);
    cameraUtils.ChangeFOV();
    animator.SetBool("Landing", true);
  }
  void Landing_Update()
  {
    Vector3 direction = landingIndicatorInstance.position - transform.position;
    int layer = 1 << LayerMask.NameToLayer("Environment");
    if (Physics.Raycast(transform.position, direction, 8f, layer)) animator.SetBool("Landing", false);
    if (controller.isGrounded) fsm.ChangeState(States.Default);
  }
  void Landing_Exit()
  {
    characterMotor.useGravity = true;
    cameraUtils.ResetFOV();
    blocker.Camera = false;
    GameObject effect = Instantiate(landingEffectPrefab, landingIndicatorInstance.position, Quaternion.Euler(-90, 0, 0));
    Destroy(effect, effect.GetComponent<ParticleSystem>().main.duration);
    Destroy(landingIndicatorInstance.gameObject);
    Camera.main.GetComponentInParent<ShakeTransform>().AddShakeEvent(cameraShake);
    Invoke("RemoveMovementBlock", 1);
  }
  #endregion

  // This method gets called from animation events in childs animator controller
  public void ApplyForce() {
    impactReceiver.AddImpact(Vector3.up, launchForce);
  }

  void ChangeCameraFocus() { cameraController.ToggleShoulderLook(cameraFocusAtLaunch); }
  void ActivateLaunchParticles() { foreach (var effect in launchParticles) effect.Play(); }
  void DeActivateLaunchParticles() { foreach (var effect in launchParticles) effect.Stop(); }
  void RemoveMovementBlock() { RemoveBlocker(); }
  void DrawLanding()
  {
    Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
    RaycastHit hit;
    int layer = 1 << LayerMask.NameToLayer("Environment");
    if (Physics.Raycast(transform.position, ray.direction, out hit, 50f, layer))
    {
      landingIndicatorInstance.gameObject.SetActive(true);
      landingIndicatorInstance.position = new Vector3(hit.point.x, hit.point.y + 0.1f, hit.point.z);
      landingIndicatorInstance.rotation = Quaternion.LookRotation(hit.normal);
    }
    else landingIndicatorInstance.gameObject.SetActive(false);
  }

  public bool isBlocked
  {
    get
    {
      return blockerList.blockers.Exists(x => x.Abilities && x != blocker);
    }
  }

}