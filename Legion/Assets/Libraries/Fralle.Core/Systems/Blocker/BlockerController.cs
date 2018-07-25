using Fralle;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlockerController : MonoBehaviour
{
  [Header("Blocker Settings")]
  public BlockerList blockerList;
  public GameRules currentRules;

  void Awake()
  {
    if (blockerList == null) blockerList = ScriptableObject.CreateInstance<BlockerList>();
  }

  public void AddBlocker(Blocker blocker)
  {
    blockerList.blockers.AddIfUnique(blocker);
  }

  public void RemoveBlocker(Blocker blocker)
  {
    blockerList.blockers.RemoveIfExists(blocker);
  }

  public bool ContainsBlocker(bool? physics = false, bool? camera = false, bool? movement = false, bool? actions = false, bool? production = false)
  {
    return blockerList.blockers.Any(x =>
    physics.HasValue ? x.Physics == physics.Value :
    camera.HasValue ? x.Camera == camera.Value :
    movement.HasValue ? x.Movement == movement.Value :
    actions.HasValue ? x.Actions == actions.Value :
    production.HasValue ? x.Production == production.Value : false);
  }

  public void OnStateChange()
  {
    Debug.Log("BlockerController recognized state change");
    blockerList.blockers.Clear();
    AddBlocker(currentRules.blocker);
  }
}
