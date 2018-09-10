using System.Linq;
using UnityEngine;

public class AutoReferencer<T> : MonoBehaviour where T : AutoReferencer<T>
{
#if UNITY_EDITOR
  protected virtual void Reset()
  {
    foreach (var field in typeof(T).GetFields().Where(field => field.GetValue(this) == null))
    {
      Transform obj;
      if (transform.name == field.Name) obj = transform;
      else obj = transform.Find(field.Name);
      if (obj != null) field.SetValue(this, obj.GetComponent(field.FieldType));
    }
  }
#endif
}
