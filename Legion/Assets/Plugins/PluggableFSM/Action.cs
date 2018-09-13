using UnityEngine;

namespace Fralle
{
  public abstract class Action : ScriptableObject
  {
    public abstract void Act(IStateController controller);
  }
}