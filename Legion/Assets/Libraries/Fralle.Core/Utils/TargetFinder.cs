using System.Linq;
using UnityEngine;

public static class TargetFinder
{
  public static Collider[] FindTargetsWithDamageable(LayerMask layerMask, float maxRange, Vector3 position)
  {
    Collider[] colliders = Physics.OverlapSphere(position, maxRange, layerMask);
    return colliders
      .Where(x => x.GetComponent<DamageController>())
      .OrderBy(x => (x.transform.position - position).sqrMagnitude)
      .ToArray();
  }

  public static bool HasLineOfSight(GameObject origin, GameObject target, out RaycastHit hit, float range, LayerMask layerMask)
  {
    Ray ray = new Ray(origin.transform.position, target.transform.position - origin.transform.position);
    Debug.DrawRay(origin.transform.position, target.transform.position - origin.transform.position, Color.red, 0.5f);
    return Physics.Raycast(ray, out hit, range, layerMask);
  }

  public static bool HasLineOfSightRadius(GameObject origin, GameObject target, out RaycastHit hit, float range, float sphereCastRadius, LayerMask layerMask)
  {
    Ray ray = new Ray(origin.transform.position, target.transform.position - origin.transform.position);
    Debug.DrawRay(origin.transform.position, target.transform.position - origin.transform.position, Color.red, 0.5f);
    return Physics.SphereCast(ray, sphereCastRadius, out hit, range, layerMask);
  }
}
