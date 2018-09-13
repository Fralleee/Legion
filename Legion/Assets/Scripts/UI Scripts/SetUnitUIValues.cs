using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetUnitUIValues : MonoBehaviour
{
  [SerializeField] Image icon;
  [SerializeField] TextMeshProUGUI nameText;
  [SerializeField] TextMeshProUGUI typeText;
  [SerializeField] TextMeshProUGUI hotKeyText;
  [SerializeField] GameObject goldCostGo;
  [SerializeField] TextMeshProUGUI goldAmountText;
  [SerializeField] GameObject woodCostGo;
  [SerializeField] TextMeshProUGUI woodAmountText;
  public void Initialize(UnitBuilding unit, int hotkey)
  {
    icon.sprite = unit.sprite;
    nameText.text = unit.name;
    typeText.text = unit.type.ToString();
    hotKeyText.text = hotkey.ToString();
    if(unit.goldCost > 0)
    {
      goldCostGo.SetActive(true);
      goldAmountText.text = unit.goldCost.ToString();
    }
    if (!(unit.woodCost > 0)) return;
    woodCostGo.SetActive(true);
    woodAmountText.text = unit.woodCost.ToString();
  }
}
