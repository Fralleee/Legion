using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blocker/Blockers List")]
public class BlockerList : ScriptableObject
{
  public List<Blocker> blockers = new List<Blocker>();
  void OnEnable() { blockers = new List<Blocker>(); }
}
