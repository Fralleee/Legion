using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/State")]
public class State : ScriptableObject
{
  public Action[] actions;
  public Transition[] transitions;
  public Color sceneGizmoColor = Color.grey;

  public void UpdateState(IStateController controller)
  {
    DoActions(controller);
    CheckTransitions(controller);
  }

  void DoActions(IStateController controller)
  {
    for (int i = 0; i < actions.Length; i++)
    {
      actions[i].Act(controller);
    }
  }

  void CheckTransitions(IStateController controller)
  {
    for (int i = 0; i < transitions.Length; i++)
    {
      bool decisionSucceeded = transitions[i].decision.Decide(controller);
      if (decisionSucceeded) controller.TransitionToState(transitions[i].trueState);
      else controller.TransitionToState(transitions[i].falseState);
    }
  }


}