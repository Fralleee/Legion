using System.Linq;
using System.Reflection;
using UnityEngine;

public class AutoReferencer<T> : MonoBehaviour where T : AutoReferencer<T>
{
#if UNITY_EDITOR
  protected virtual void Reset()
  {
    foreach (FieldInfo field in typeof(T).GetFields().Where(field => field.GetValue(this) == null))
    {
      Transform obj = transform.name == field.Name ? transform : transform.Find(field.Name);
      if (obj != null) field.SetValue(this, obj.GetComponent(field.FieldType));
    }
  }
#endif
}
