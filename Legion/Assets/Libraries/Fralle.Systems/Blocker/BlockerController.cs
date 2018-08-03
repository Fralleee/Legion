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
    if (blockerList == null)
    {
      blockerList = ScriptableObject.CreateInstance<BlockerList>();
    }
  }

  public void AddBlocker(Blocker blocker)
  {
    blockerList.blockers.AddIfUnique(blocker);
  }

  public void RemoveBlocker(Blocker blocker)
  {
    blockerList.blockers.RemoveIfExists(blocker);
  }

  public bool ContainsBlocker(bool? physics = null, bool? camera = null, bool? movement = null, bool? abilities = null, bool? production = null)
  {
    return blockerList.blockers.Any(x =>
    physics.HasValue ? (x.Physics == physics.Value) :
    camera.HasValue ? x.Camera == camera.Value :
    movement.HasValue ? x.Movement == movement.Value :
    abilities.HasValue ? x.Abilities == abilities.Value :
    production.HasValue ? x.Production == production.Value : false);
  }

  public void OnStateChange()
  {
    Debug.Log("BlockerController recognized state change");
    blockerList.blockers.Clear();
    AddBlocker(currentRules.blocker);
  }
}
