using UnityEngine;

public interface ITargeter
{
  Target currentTarget { get; set; }
  Target mainTarget { get; set; }
  Target objective { get; set; }  
  LayerMask teamLayerMask { get; set; }
  LayerMask enemyLayerMask { get; set; }
  LayerMask spawnLayerMask { get; set; }
  LayerMask environmentLayerMask { get; set; }
  int teamLayer { get; set; }
  int enemyLayer { get; set; }
  int spawnLayer { get; set; }
  int environmentLayer { get; set; }
}
