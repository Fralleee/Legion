using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
  public void Initialize(Placeable p)
  {
    transform.Find("Name").GetComponent<Text>().text = p.name;
    transform.Find("Gold").GetComponent<Text>().text = p.gold.ToString();
    transform.Find("Wood").GetComponent<Text>().text = p.wood.ToString();
  }
}
