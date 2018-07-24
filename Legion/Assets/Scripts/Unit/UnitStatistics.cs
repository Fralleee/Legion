using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatistics : ScriptableObject
{

  [SerializeField] float health = 100f;
  [SerializeField] float armor = 0f;

  // This could be attacks, abilities, wutevah
  [SerializeField] List<int> actions;

}
