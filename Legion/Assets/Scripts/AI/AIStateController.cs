using Fralle;
using UnityEngine;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(AIMotor))]
[RequireComponent(typeof(AICaster))]
[RequireComponent(typeof(BlockerController))]
public class AIStateController : MonoBehaviour, IStateController
{
  [HideInInspector] public float stateTimeElapsed;
  public State currentState;
  public State remainState;
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
  }
  void Start()
  {
    GameManager.DestroyUnits += Despawn;
    motor.SetStoppingDistance(caster.MainAbility.range);
  }
  void Update()
  {
    currentState.UpdateState(this);
  }
  void Despawn()
  {
    GameManager.DestroyUnits -= Despawn;
    Destroy(gameObject);
  }

  void OnDrawGizmos()
  {
    if (currentState != null)
    {
      Gizmos.color = currentState.sceneGizmoColor;
      Gizmos.DrawWireSphere(transform.position, targeter ? targeter.LookRange : 15f);
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