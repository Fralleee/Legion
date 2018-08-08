using UnityEngine;
using UnityEngine.UI;

public class ImageFillSetterRange : MonoBehaviour
{
  public RangeVariable Variable;
  Image Image;
  void Start() { Image = GetComponent<Image>(); }
  void Update() { Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Variable.minValue, Variable.maxValue, Variable.value)); }
}