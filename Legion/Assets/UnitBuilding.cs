using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName="Shop/Unit")]
public class UnitBuilding : ScriptableObject
{
  public Sprite sprite;
  public float goldCost = 10;
  public float woodCost;
  public GameObject building;
  public GameObject unit;
  

}
