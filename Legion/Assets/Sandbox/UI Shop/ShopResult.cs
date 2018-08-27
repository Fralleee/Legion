using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopResult : MonoBehaviour
{
  [SerializeField] List<ShopItem> shopItems = new List<ShopItem>();
  [SerializeField] InputField filterText;
  [SerializeField] Text infoText;
  List<GameObject> shopItemInstances = new List<GameObject>();

  void Validate()
  {
    if (shopItems.Count == 0) Debug.LogWarning("ShopResult: ShopItems list is empty.");
    if (filterText == null) Debug.LogWarning("ShopResult: FilterText is null.");
    if (infoText == null) Debug.LogWarning("ShopResult: InfoText is null.");
  }

  void Start()
  {
    Validate();
    foreach (ShopItem item in shopItems)
    {
      GameObject instance = Instantiate(item.buttonPrefab, transform);
      shopItemInstances.Add(instance);
    }    
  }

  public void Filter(ShopType shopType)
  {
    foreach (GameObject item in shopItemInstances)
    {
      item.SetActive(true);
      ShopItem shopItem = item.GetComponent<ShopItem>();
      if (shopType != ShopType.All && shopItem.shopType != shopType) item.SetActive(false);
      else if (!string.IsNullOrEmpty(filterText.text) && !item.name.Contains(filterText.text)) item.SetActive(false);
    }    
    infoText.text = "Now viewing " + shopItemInstances.Count(item => item.activeSelf) + " of " + shopItems.Count + " items";
  }

}
