using UnityEngine;
using UnityEngine.UI;

public class StringRangeTextSetter : MonoBehaviour
{
  [SerializeField] StringRangeVariable range;
  Text text;
  void Start() { text = GetComponent<Text>(); }
  void Update() { text.text = range.text; }
}
