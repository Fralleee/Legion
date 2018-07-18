using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingUI : MonoBehaviour
{
  [SerializeField] ActiveBuilding currentPlaceable;
  Placeable placeable;
  public void Initialize(Placeable p)
  {
    placeable = p;
    transform.Find("Name").GetComponent<Text>().text = p.name;
    transform.Find("Gold").GetComponent<Text>().text = p.gold.ToString();
    transform.Find("Wood").GetComponent<Text>().text = p.wood.ToString();
  }

  public void SetCurrentPlaceable()
  {
    currentPlaceable.placeable = placeable;
    currentPlaceable.placeable.Initiate(GameObject.Find("Player").transform);
  }
}
