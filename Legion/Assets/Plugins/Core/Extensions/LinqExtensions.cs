using System.Collections.Generic;
using UnityEngine;

namespace Fralle
{
  public static class LinqExtensions
  {
    public static void AddIfUnique<T>(this List<T> list, T element)
    {
      if (!list.Contains(element)) list.Add(element);
    }
    public static void RemoveIfExists<T>(this List<T> list, T element)
    {
      if (list.Contains(element)) list.Remove(element);
    }
  }
}