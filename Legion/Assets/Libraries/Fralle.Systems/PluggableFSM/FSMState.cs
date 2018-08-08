using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableFSM/State")]
public class FSMState : ScriptableObject
{
  public FSMAction[] actions;
  public FSMTransition[] transitions;
  public Color sceneGizmoColor = Color.grey;

  public void UpdateState(FSMStateController controller)
  {
    DoActions(controller);
    CheckTransitions(controller);
  }

  void DoActions(FSMStateController controller)
  {
    for (int i = 0; i < actions.Length; i++)
    {
      actions[i].Act(controller);
    }
  }

  void CheckTransitions(FSMStateController controller)
  {
    for (int i = 0; i < transitions.Length; i++)
    {
      bool decisionSucceeded = transitions[i].decision.Decide(controller);
      if (decisionSucceeded) controller.TransitionToState(transitions[i].trueState);
      else controller.TransitionToState(transitions[i].falseState);
    }
  }


}