using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fralle
{
  public interface IStateController
  {
    void TransitionToState(State nextState);
  }
}
