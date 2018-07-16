using UnityEngine;
using UnityEngine.UI;

public class UpdateHealthUI : MonoBehaviour
{

  public FloatVariable variable;
  Text text;

  void Start()
  {
    text = GetComponent<Text>();
    text.text = Mathf.Round(variable.currentValue).ToString();
  }

  void Update() { text.text = Mathf.Round(variable.currentValue).ToString(); }

}
