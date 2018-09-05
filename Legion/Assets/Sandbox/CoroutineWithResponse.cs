using System.Collections;
using UnityEngine;

public class CoroutineWithResponse
{
  public Coroutine coroutine { get; private set; }
  public object result;
  IEnumerator target;
  public CoroutineWithResponse(MonoBehaviour owner, IEnumerator target)
  {
    this.target = target;
    coroutine = owner.StartCoroutine(Run());
  }

  IEnumerator Run()
  {
    while (target.MoveNext())
    {
      result = target.Current;
      yield return result;
    }
  }
}