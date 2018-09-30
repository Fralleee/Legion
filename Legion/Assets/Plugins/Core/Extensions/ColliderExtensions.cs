using UnityEngine;

namespace Fralle
{
  public static class ColliderExtensions
  {
    public static float ClosestDistance(this Collider a, Collider b)
    {
      return Vector3.Distance(a.ClosestPointOnBounds(b.transform.position), b.ClosestPointOnBounds(a.transform.position));
    }
    public static float ClosestDistanceSqrt(this Collider a, Collider b)
    {
      return Vector3.SqrMagnitude(a.ClosestPointOnBounds(b.transform.position) -
                                  b.ClosestPointOnBounds(a.transform.position));
    }
  }
}