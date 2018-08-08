using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour, IStateController
{
  [HideInInspector] public float stateTimeElapsed;
  public State currentState;
  public State remainState;
  
  void Update()
  {
    currentState.UpdateState(this);
  }

  void OnDrawGizmos()
  {
    if (currentState != null)
    {
      Gizmos.color = currentState.sceneGizmoColor;
      Gizmos.DrawSphere(transform.position, 15f);
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