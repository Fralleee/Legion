using System;

[Serializable]
public class AITransition
{
  public AIDecision decision;
  public AIState trueState;
  public AIState falseState;
}