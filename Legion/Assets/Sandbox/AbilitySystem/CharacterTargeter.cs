using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterTargeter : MonoBehaviour, ITargeter
{
  public Target currentTarget { get; set; }
  public Target mainTarget { get; set; }
  public Target objective { get; set; }
  public LayerMask EnvironmentLayerMask;
  public LayerMask EnemyLayerMask;
  public int EnemyLayer;
  public int SpawnLayer;
  public int GetTargetLayer(AbilityTargetTeam targetTeam) { return targetTeam == AbilityTargetTeam.Hostile ? EnemyLayer : gameObject.layer; }
  public int GetSpawnLayer() { return SpawnLayer; }
  public bool FindTarget(Ability ability) { return true; }
}
