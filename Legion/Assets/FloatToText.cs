using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatToText : MonoBehaviour
{
  [SerializeField] FloatReference value;
  Text text;
  void Start() { text = GetComponent<Text>(); }
  void Update() { text.text = value > 0 ? Mathf.Ceil(value).ToString() : ""; }
}