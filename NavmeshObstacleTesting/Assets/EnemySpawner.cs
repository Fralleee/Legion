using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
  public float spawnRadius = 10;
  public int numberOfAgents = 50;
  public GameObject enemyPrefab;
  public Transform player;
  void Start()
  {
    for (int i = 0; i < numberOfAgents; i++)
    {
      Vector2 randomLoc2d = Random.insideUnitCircle * spawnRadius;
      Vector3 randomLoc3d = new Vector3(transform.position.x + randomLoc2d.x, transform.position.y, transform.position.z + randomLoc2d.y);
      NavMeshHit hit;
      if (NavMesh.SamplePosition(randomLoc3d, out hit, 100, 1))
      {
        randomLoc3d = hit.position;
      }
      GameObject o = Instantiate(enemyPrefab, randomLoc3d, transform.rotation);
      o.GetComponent<EnemyMovement>().player = player;
    }
  }
  void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(transform.position, spawnRadius);
  }
}