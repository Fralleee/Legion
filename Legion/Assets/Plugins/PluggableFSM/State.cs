using UnityEngine;

namespace Fralle
{
  [CreateAssetMenu(menuName = "AI/State")]
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
      foreach (Action t in actions)
      {
        t.Act(controller);
      }
    }

    void CheckTransitions(IStateController controller)
    {
      foreach (Transition t in transitions)
      {
        bool decisionSucceeded = t.decision.Decide(controller);
        controller.TransitionToState(decisionSucceeded ? t.trueState : t.falseState);
      }
    }
  }
}