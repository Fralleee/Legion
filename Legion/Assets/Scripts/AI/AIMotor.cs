using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AITargeter))]
[RequireComponent(typeof(BlockerController))]
public class AIMotor : MonoBehaviour
{
  [HideInInspector] public NavMeshAgent navMeshAgent;
  public float travelSpeed = 4f;
  public float chasingSpeed = 6f;
  public float wanderTimer = 5f;

  BlockerController blockerController;
  public bool IsBlocked { get { return blockerController.ContainsBlocker(movement: true); } }

  void Awake()
  {
    blockerController = GetComponent<BlockerController>();
    navMeshAgent = GetComponent<NavMeshAgent>();
  }
}