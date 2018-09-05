//using System.Collections.Generic;
//using UnityEngine;

//public abstract class AIAbility : Ability
//{
//  public bool requireLineOfSight = true;
//  public float targetScanRate = 0.5f;
//  public TargetType targetType = TargetType.HOSTILE;
//  public TargetPriority targetPriority = TargetPriority.NEAREST;
//  [HideInInspector] public float lastTargetScan = 0;
//  [HideInInspector] public float lastLoSCheck = 0;
//  [HideInInspector] public float losScanRate = 0.25f;

//  public override void Setup(GameObject casterGo, int targetLayerParam)
//  {
//    base.Setup(casterGo, targetLayerParam);
//    lastLoSCheck = 0;
//    lastTargetScan = 0;
//  }

//  public virtual void Cast(GameObject target) { lastAction = Time.time + cooldown; }

//}
