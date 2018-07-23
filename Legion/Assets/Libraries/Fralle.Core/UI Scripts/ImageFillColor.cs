using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageFillColor : MonoBehaviour
{
  public Color readyColor = Color.white;
  public Color cooldownColor = Color.yellow;
  Image image;
  void OnEnable() { image = GetComponent<Image>(); }
  void Update() { image.color = image.fillAmount >= 1 ? readyColor : cooldownColor; }
}
