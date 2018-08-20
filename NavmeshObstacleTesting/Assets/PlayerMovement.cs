using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
  NavMeshAgent agent;
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }
  void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;
      LayerMask mask = 1 << 9;
      if (Physics.Raycast(ray, out hit, 500, mask))
      {
        agent.destination = hit.point;
      }
    }
  }
}