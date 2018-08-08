using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITargeter
{
  Target CurrentTarget { get; set; }
  Target MainTarget { get; set; }
  Target Objective { get; set; }
  [HideInInspector] float lastScan { get; set; }
  [HideInInspector] float lastLosCheck { get; set; }
  [HideInInspector] bool lastLosResult { get; set; }  
  bool PerformLoSCheck { get; }
}

