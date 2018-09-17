using Fralle;
using System.Linq;
using UnityEngine;

public class BlockerController : MonoBehaviour
{
  [SerializeField] BlockerList blockerList;
  public bool Physics;
  public bool Camera;
  public bool Movement;
  public bool Rotation;
  public bool Abilities;
  public bool Production;

  void Awake() { if (blockerList == null) { blockerList = ScriptableObject.CreateInstance<BlockerList>(); } }

  void ValidateBlockers()
  {
    Physics = blockerList.blockers.Any(x => x.Physics);
    Camera = blockerList.blockers.Any(x => x.Camera);
    Movement = blockerList.blockers.Any(x => x.Movement);
    Rotation = blockerList.blockers.Any(x => x.Rotation);
    Abilities = blockerList.blockers.Any(x => x.Abilities);
    Production = blockerList.blockers.Any(x => x.Production);
  }

  public void AddBlocker(Blocker blocker)
  {
    if (!blocker) return;
    blockerList.blockers.AddIfUnique(blocker);
    ValidateBlockers();
  }

  public void RemoveBlocker(Blocker blocker)
  {
    if (!blocker) return;
    blockerList.blockers.RemoveIfExists(blocker);
    ValidateBlockers();
  }

}
