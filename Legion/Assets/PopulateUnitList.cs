using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateUnitList : MonoBehaviour
{
  [SerializeField] GameObject unitPrefab;
  [SerializeField] List<UnitBuilding> units;

	void Start ()
  {
    for (int i = 0; i < units.Count; i++)
    {
      GameObject instance = Instantiate(unitPrefab, transform);
      instance.transform.Find("Icon").GetComponent<Image>().sprite = units[i].sprite;
      instance.transform.Find("Text").GetComponent<Text>().text = units[i].name;
      instance.GetComponent<SelectStoreUnit>().unit = units[i];
      instance.GetComponent<SelectStoreUnit>().keyCode = (KeyCode)i+49;
    }
    //foreach (UnitBuilding unit in units)
    //{
    //  GameObject instance = Instantiate(unitPrefab, transform);
    //  instance.transform.Find("Icon").GetComponent<Image>().sprite = unit.sprite;
    //  instance.transform.Find("Text").GetComponent<Text>().text = unit.name;
    //  instance.GetComponent<SelectStoreUnit>().unit = unit;
    //  instance.GetComponent<SelectStoreUnit>().keyCode = 
    //}
	}	
	
}
