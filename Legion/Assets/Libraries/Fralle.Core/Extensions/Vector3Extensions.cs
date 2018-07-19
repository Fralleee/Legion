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
  }
}
