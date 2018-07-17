using UnityEngine;
using UnityEngine.UI;

public class TextSetter : MonoBehaviour
{
  [SerializeField] StringRangeVariable range;
  Text text;
  void Start() { text = GetComponent<Text>(); }
  void Update() { text.text = range.text; }
}
