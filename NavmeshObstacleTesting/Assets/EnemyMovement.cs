
using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
  public Transform player;
  public Transform model;
  public Transform proxy;
  NavMeshAgent agent;
  NavMeshObstacle obstacle;
  Vector3 lastPosition;
  void Start()
  {
    agent = proxy.GetComponent<NavMeshAgent>();
    obstacle = proxy.GetComponent<NavMeshObstacle>();
  }
  void Update()
  {
    if ((player.position - proxy.position).sqrMagnitude < Mathf.Pow(agent.stoppingDistance, 2))
    {
      agent.enabled = false;
      obstacle.enabled = true;
    }
    else
    {
      obstacle.enabled = false;
      agent.enabled = true;
      agent.destination = player.position;
    }
    model.position = Vector3.Lerp(model.position, proxy.position, Time.deltaTime * 2);
    Vector3 orientation = model.position - lastPosition;
    if (orientation.sqrMagnitude > 0.1f)
    {
      orientation.y = 0;
      model.rotation = Quaternion.Lerp(model.rotation, Quaternion.LookRotation(model.position - lastPosition), Time.deltaTime * 8);
    }
    else
    {
      model.rotation = Quaternion.Lerp(model.rotation, Quaternion.LookRotation(proxy.forward), Time.deltaTime * 8);
    }
    lastPosition = model.position;
  }
}