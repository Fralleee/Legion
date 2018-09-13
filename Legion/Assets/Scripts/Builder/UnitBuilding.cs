using UnityEngine;

public enum UnitType
{
  TANK,
  WARRIOR,
  RANGED,
  ASSASSIN,
  CASTER,
  SIEGE
}

[CreateAssetMenu(menuName="Match/Units/ShopButton")]
public class UnitBuilding : ScriptableObject
{
  public UnitType type = UnitType.WARRIOR;
  public Sprite sprite;
  public float goldCost = 10;
  public float woodCost;
  public GameObject building;
  public GameObject unit;
  

}
