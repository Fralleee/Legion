using System.Collections;
using System.Collections.Generic;
using TMPro;
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
      instance.GetComponent<SetUnitUIValues>().Initialize(units[i], i + 1);      
      instance.GetComponent<SelectStoreUnit>().unit = units[i];
      instance.GetComponent<SelectStoreUnit>().keyCode = (KeyCode)i + 49;
    }
  }

}
