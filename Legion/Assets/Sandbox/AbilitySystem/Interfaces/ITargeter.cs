using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargeter
{
  Target currentTarget { get; set; }
  Target mainTarget { get; set; }
  Target objective { get; set; }
  bool FindTarget(Ability ability);
  int GetTargetLayer(AbilityTargetTeam targetTeam);
}
