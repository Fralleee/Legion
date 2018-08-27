using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShopCategory : MonoBehaviour
{
  [SerializeField] ShopType shopType;
  [SerializeField] ShopResult shopResult;  
  public void OnClick()
  {
    shopResult.Filter(shopType);
  }

}
