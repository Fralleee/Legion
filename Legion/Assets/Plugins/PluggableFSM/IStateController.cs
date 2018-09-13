namespace Fralle
{
  public interface IStateController
  {
    void TransitionToState(State nextState);
  }
}
