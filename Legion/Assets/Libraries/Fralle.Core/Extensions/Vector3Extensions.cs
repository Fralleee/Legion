using UnityEngine;

namespace Fralle
{
  public static class Vector3Extensions
  {
    public static Vector3 SnapToGrid(this Vector3 vector, float gridSize)
    {
      return new Vector3(
        Mathf.Round(vector.x / gridSize) * gridSize,
        Mathf.Round(vector.y / gridSize) * gridSize,
        Mathf.Round(vector.z / gridSize) * gridSize
      );
    }
    public static Vector3 With(this Vector3 v, float? x = null, float? y = null, float? z = null)
    {
      float newX = x.HasValue ? x.Value : v.x;
      float newY = y.HasValue ? y.Value : v.y;
      float newZ = z.HasValue ? z.Value : v.z;
      return new Vector3(newX, newY, newZ);
    }
    public static Vector3 WithX(this Vector3 v, float x)
    {
      return new Vector3(x, v.y, v.z);
    }
    public static Vector3 WithY(this Vector3 v, float y)
    {
      return new Vector3(v.x, y, v.z);
    }
    public static Vector3 WithZ(this Vector3 v, float z)
    {
      return new Vector3(v.x, v.y, z);
    }
  }
}
