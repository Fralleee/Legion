using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateController
{
  void TransitionToState(State nextState);
}
