using UnityEngine;
using Fralle;

public partial class BlockerBehaviour : MonoBehaviour
{
  [Header("Blocker Settings")]
  [SerializeField] protected BlockerList blockerList;
  [SerializeField] protected Blocker blocker;

  protected void ApplyBlocker()
  {
    blockerList.blockers.AddIfUnique(blocker);
  }

  protected void RemoveBlocker()
  {
    blockerList.blockers.RemoveIfExists(blocker);
  }

}
