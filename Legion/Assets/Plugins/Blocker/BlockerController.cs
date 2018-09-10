using Fralle;
using System.Linq;
using UnityEngine;

public class BlockerController : MonoBehaviour
{
  public BlockerList blockerList;
  void Awake() { if (blockerList == null) { blockerList = ScriptableObject.CreateInstance<BlockerList>(); } }
  public void AddBlocker(Blocker blocker) { if (blocker) blockerList.blockers.AddIfUnique(blocker); }
  public void RemoveBlocker(Blocker blocker) { if (blocker) blockerList.blockers.RemoveIfExists(blocker); }
  public bool ContainsBlocker(bool? physics = null, bool? camera = null, bool? movement = null, bool? rotation = null, bool? abilities = null, bool? production = null)
  {
    return blockerList.blockers.Any(x =>
    physics.HasValue ? (x.Physics == physics.Value) :
    camera.HasValue ? x.Camera == camera.Value :
    movement.HasValue ? x.Movement == movement.Value :
    rotation.HasValue ? x.Rotation == rotation.Value :
    abilities.HasValue ? x.Abilities == abilities.Value :
    production.HasValue ? x.Production == production.Value : false);
  }
}
