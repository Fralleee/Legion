﻿using Fralle;
using UnityEngine;

// TEmporary
public class TeamData : ScriptableObject
{
  public GameObject objective;
}

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(AIMotor))]
[RequireComponent(typeof(AICaster))]
[RequireComponent(typeof(BlockerController))]
public class AIStateController : MonoBehaviour, IStateController
{
  [HideInInspector] public float stateTimeElapsed;
  public State currentState;
  public State remainState;

  public TeamData teamData;
  [HideInInspector] public AITargeter targeter;
  [HideInInspector] public AIMotor motor;
  [HideInInspector] public AICaster caster;
  BlockerController blockerController;
  public bool IsBlocked { get { return blockerController.ContainsBlocker(movement: true); } }

  void Awake()
  {
    targeter = GetComponent<AITargeter>();
    motor = GetComponent<AIMotor>();
    caster = GetComponent<AICaster>();
    blockerController = GetComponent<BlockerController>();
    Debug.LogWarning("Code in Update that should be moved to decision.");
  }

  void Update()
  {
    // This code should be an action/decision 
    if (targeter.Objective == null && teamData.objective) targeter.SetObjective(teamData.objective);
    currentState.UpdateState(this);
  }

  void OnDrawGizmos()
  {
    if (currentState != null)
    {
      Gizmos.color = currentState.sceneGizmoColor;
      Gizmos.DrawWireSphere(transform.position, 15f);
    }
  }

  public void TransitionToState(State nextState)
  {
    if (nextState != remainState)
    {
      currentState = nextState;
      OnExitState();
    }
  }

  public bool CheckIfCountDownElapsed(float duration)
  {
    stateTimeElapsed += Time.deltaTime;
    return (stateTimeElapsed >= duration);
  }

  void OnExitState()
  {
    stateTimeElapsed = 0;
  }
}