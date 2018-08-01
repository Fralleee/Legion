using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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

  // Targeting
  public Transform eyes;
  public LayerMask environmentLayerMask;
  public LayerMask enemyLayerMask;
  public float lookRange = 15f;
  public float targetWidth = 0.5f;
  [HideInInspector] public Target currentTarget;
  [HideInInspector] public Target objective;
  public Target target { get { return currentTarget ?? objective; } }

  // Ability
  public List<Ability> hostileAbilities = new List<Ability>();

  void Awake()
  {
    navMeshAgent = GetComponent<NavMeshAgent>();
  }

  void Update()
  {
    Debug.Log("objective == null: " + (objective == null));
    Debug.Log("teamData.objective: " + teamData.objective);
    if (objective == null && teamData.objective)
    {
      objective = new Target(teamData.objective.transform);
      Debug.Log(objective);
    }
    currentState.UpdateState(this);
  }

  void OnDrawGizmos()
  {
    if (currentState != null && eyes != null)
    {
      Gizmos.color = currentState.sceneGizmoColor;
      Gizmos.DrawWireSphere(eyes.position, lookRange);
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

  private void OnExitState()
  {
    stateTimeElapsed = 0;
  }
}