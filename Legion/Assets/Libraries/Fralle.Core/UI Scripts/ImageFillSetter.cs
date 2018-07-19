using UnityEngine;
using UnityEngine.UI;

public class ImageFillSetter : MonoBehaviour
{
  public FloatReference Variable;
  public FloatReference Min;
  public FloatReference Max;
  Image Image;
  void Start() { Image = GetComponent<Image>(); }
  void Update() { Image.fillAmount = Mathf.Clamp01(Mathf.InverseLerp(Min, Max, Variable)); }
}