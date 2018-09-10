using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fralle
{
  public abstract class Action : ScriptableObject
  {
    public abstract void Act(IStateController controller);
  }
}