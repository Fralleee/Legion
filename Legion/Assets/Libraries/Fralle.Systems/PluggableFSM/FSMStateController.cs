using UnityEngine;
using UnityEngine.AI;

public class FSMStateController : MonoBehaviour
{
  [HideInInspector] public float stateTimeElapsed;
  public FSMState currentState;
  public FSMState remainState;
  
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

  public void TransitionToState(FSMState nextState)
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