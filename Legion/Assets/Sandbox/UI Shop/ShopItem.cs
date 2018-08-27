using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ShopItem")]
public class ShopItem : ScriptableObject
{

  public string description;

  public int goldCost = 10;
  public int woodCost;

  public ShopType shopType = ShopType.Item;

  public Sprite sprite;
  public GameObject buttonPrefab;

}
