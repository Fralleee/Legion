using UnityEngine;
using UnityEngine.UI;
using Fralle;

public class FloatReferenceTextSetter : MonoBehaviour
{
  [SerializeField] FloatReference value;
  Text text;
  [SerializeField] bool showOnlyWhenPositive;
  void Start() { text = GetComponent<Text>(); }
  void Update() {
    if(showOnlyWhenPositive) text.text = value > 0 ? value.Value.Ceil().ToString() : "";
    else text.text = value.Value.Ceil().ToString();
  }
}