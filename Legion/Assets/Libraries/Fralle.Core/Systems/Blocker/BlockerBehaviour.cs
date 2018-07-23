using UnityEngine;
using Fralle;

public class BlockerBehaviour : MonoBehaviour
{
  [Header("Blocker Settings")]
  [SerializeField] protected BlockerList blockerList;
  [SerializeField] protected Blocker blocker;
  [SerializeField] protected GameRules currentRules;

  protected void ApplyBlocker(Blocker b)
  {
    blockerList.blockers.AddIfUnique(b);
  }

  protected void ApplyBlocker()
  {
    blockerList.blockers.AddIfUnique(blocker);
  }

  protected void RemoveBlocker()
  {
    blockerList.blockers.RemoveIfExists(blocker);
  }

  public void OnStateChange()
  {
    Debug.Log("BlockerBehaviour recognized state change");
    blockerList.blockers.Clear();
    ApplyBlocker(currentRules.blocker);
  }

}
