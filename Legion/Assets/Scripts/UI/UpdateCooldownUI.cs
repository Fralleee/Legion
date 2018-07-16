using UnityEngine;
using UnityEngine.UI;

public class UpdateCooldownUI : MonoBehaviour
{

  public FloatVariable variable;
  Text text;

  void Start()
  {
    text = GetComponent<Text>();
    text.text = "";
  }

  void Update()
  {
    if (variable.currentValue > 0) text.text = Mathf.Round(variable.currentValue).ToString();
    else text.text = "";
  }

}
