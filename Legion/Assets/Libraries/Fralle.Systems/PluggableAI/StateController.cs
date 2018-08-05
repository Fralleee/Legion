using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(AICaster))]
[RequireComponent(typeof(BlockerController))]
public class StateController : MonoBehaviour
{
  public TeamData teamData;

  [HideInInspector] public float stateTimeElapsed;
  public State currentState;
  public State remainState;

  // Movement
  [HideInInspector] public NavMeshAgent navMeshAgent;
  public float travelSpeed = 4f;
  public float chasingSpeed = 6f;
  public float wanderTimer;

  [HideInInspector] public AITargeter targeter;
  [HideInInspector] public AICaster caster;

  BlockerController blockerController;
  public bool IsBlocked { get { return blockerController.ContainsBlocker(movement: true); } }

  void Awake()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
    targeter = GetComponent<AITargeter>();
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
      Gizmos.DrawSphere(transform.position, targeter ? targeter.LookRange : 15f);
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