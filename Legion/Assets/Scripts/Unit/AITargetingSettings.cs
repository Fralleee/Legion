using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stats/AI Targeting Settings")]
public class AITargetingSettings : ScriptableObject
{
  [SerializeField] float lastAttackBuffer = 4f;
  [SerializeField] float lastHostileScanBuffer = 1f;

  [Range(15, 100)] public float hostileScanRange;
  public LayerMask enemyLayerMask;

  public float lastAttack = 8f;  
  public float lastHostileScan = 0f;
  

  public void SetLastAttack(float extraTime = 0)
  {
    lastAttack = Time.time + extraTime + lastAttackBuffer;
  }

  public void SetHostileScanRange(float maxRangeInActions)
  {    
    hostileScanRange = Mathf.Clamp(Mathf.Max(hostileScanRange, maxRangeInActions), 15, 100);    
  }
  public void SetLastHostileScan()
  {
    lastHostileScan = Time.time + lastHostileScanBuffer;
  }
}
