//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using UnityEngine;

//[CreateAssetMenu(menuName = "Abilities/Projectile")]
//public class ProjectileAbility : Ability
//{
//  public GameObject ProjectilePrefab { get; set; }
//  public bool ArcLauncher { get; set; }
//  public float Force = 1000f;

//  [Header("Projectile ability specific")]
//  [SerializeField] private GameObject projectilePrefab;
//  [SerializeField] private bool arcLauncher;

//  public override void Setup(GameObject caster)
//  {
//    base.Setup(caster);
//    ProjectilePrefab = projectilePrefab;
//    ArcLauncher = arcLauncher;
//  }

//  public override void Cast(GameObject target)
//  {
//    if (ArcLauncher)
//    {
//      LaunchProjectileArc(target.transform.position);
//    }
//    else
//    {
//      LaunchProjectile();
//    }
//  }

//  private void LaunchProjectile()
//  {
//    var rnd = new System.Random();
//    int amount = rnd.Next(MinAmount, MaxAmount);
//    lastAction = Time.time;

//    var instance = Instantiate(ProjectilePrefab, Caster.transform.position + (Vector3.up * 0.5f), Quaternion.identity);
//    instance.GetComponent<Rigidbody>().AddForce(Caster.transform.forward * Force);
//    instance.GetComponent<Projectile>().Setup(Caster.GetComponent<Unit>().teamInfo, amount, AbilityRange);
//  }

//  private void LaunchProjectileArc(Vector3 position)
//  {
//    var rnd = new System.Random();
//    int amount = rnd.Next(MinAmount, MaxAmount);
//    lastAction = Time.time;

//    var instance = Instantiate(ProjectilePrefab, Caster.transform.position + ((Vector3.up + Caster.transform.forward) * 0.75f), Quaternion.identity);


//    float distance = Vector3.Distance(position, Caster.transform.position);

//    float verticalSpeed = Mathf.Sqrt(2 * -Physics.gravity.y);
//    float expectedTravelTime = Mathf.Sqrt (2 / -Physics.gravity.y)+Mathf.Sqrt(2 -Physics.gravity.y);
//    float horizontalSpeed = distance / expectedTravelTime;

//    Vector3 normalizedForwardDir = Caster.transform.forward.normalized;
//    Vector3 launchVector = new Vector3 (normalizedForwardDir.x * horizontalSpeed, verticalSpeed, normalizedForwardDir.z * horizontalSpeed);

//    instance.GetComponent<Rigidbody>().AddForce(launchVector * 100);
//    instance.GetComponent<Projectile>().Setup(Caster.GetComponent<Unit>().teamInfo, amount, AbilityRange);
//    Destroy(instance, 10f);
//  }
//}
