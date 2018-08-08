using System;

[Serializable]
public class FSMTransition
{
  public FSMDecision decision;
  public FSMState trueState;
  public FSMState falseState;
}