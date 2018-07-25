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
}
