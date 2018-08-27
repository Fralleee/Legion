using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateUnitList : MonoBehaviour
{
  [SerializeField] GameObject unitPrefab;
  [SerializeField] List<UnitBuilding> units;

  void Start()
  {
    for (int i = 0; i < units.Count; i++)
    {
      GameObject instance = Instantiate(unitPrefab, transform);
      instance.transform.Find("Icon").GetComponent<Image>().sprite = units[i].sprite;
      instance.transform.Find("Name").GetComponent<Text>().text = units[i].name;
      instance.transform.Find("HotKey").GetComponent<Text>().text = (i + 1).ToString();
      instance.GetComponent<SelectStoreUnit>().unit = units[i];
      instance.GetComponent<SelectStoreUnit>().keyCode = (KeyCode)i + 49;
    }
  }

}
