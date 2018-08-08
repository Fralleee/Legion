//using UnityEngine;

//public class Projectile : MonoBehaviour 
//{
//  public int projectileDamage;
//  private int projectileRange;
//  private Vector3 startPosition;

//  public void Setup(TeamInfo ti, int damage, int range)
//  {
//    projectileDamage = damage;
//    projectileRange = range;
//    gameObject.layer = ti.TeamProjectileLayer;
//    startPosition = transform.position;
//  }

//  void FixedUpdate()
//  {
//    if(Vector3.Distance(startPosition, transform.position) > projectileRange)
//    {
//      Die();
//    }
//  }

//  private void OnCollisionEnter(Collision collision)
//  {
//    GameObject target = collision.gameObject;
//    DamageableObject damageController = target.GetComponent<DamageableObject>();
//    if (damageController != null)
//    {
//      target.GetComponent<DamageableObject>().Affect(projectileDamage);
//    }
//    Die();
//  }

//  private void Die()
//  {
//    ParticleSystem[] psArr = gameObject.GetComponentsInChildren<ParticleSystem>();
//    foreach (ParticleSystem ps in psArr)
//    {
//      ps.transform.parent = null;
//      Destroy(ps.gameObject, 1f);
//    }

//    Destroy(gameObject);
//  }
//}