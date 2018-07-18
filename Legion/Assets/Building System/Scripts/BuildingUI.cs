using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
  [SerializeField] FloatVariable Gold;
  [SerializeField] FloatVariable Wood;

  [SerializeField] Color errorColor;
  [SerializeField] Color successColor;

  Image image;
  float goldCost;
  float woodCost;

  void Start()
  {
    image = GetComponent<Image>();
  }

  void Update()
  {
    if (goldCost > Gold.currentValue || woodCost > Wood.currentValue) image.color = errorColor;
    else image.color = successColor;
  }

  public void Initialize(Placeable p)
  {
    goldCost = p.gold;
    woodCost = p.wood;
    transform.Find("Name").GetComponent<Text>().text = p.name;
    transform.Find("Gold").GetComponent<Text>().text = p.gold.ToString();
    transform.Find("Wood").GetComponent<Text>().text = p.wood.ToString();
  }
}
