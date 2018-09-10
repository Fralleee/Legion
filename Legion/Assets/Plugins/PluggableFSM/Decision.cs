using UnityEngine;

namespace Fralle
{
  public abstract class Decision : ScriptableObject
  {
    public abstract bool Decide(IStateController controller);
  }
}