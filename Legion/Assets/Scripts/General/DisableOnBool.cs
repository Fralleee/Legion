using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnBool : MonoBehaviour
{
  [SerializeField] BoolVariable value;
  [SerializeField] Behaviour[] behaviours;
  void Awake() { value.OnChange += OnChange; }
  void OnChange(bool newValue)
  {
    foreach (Behaviour behaviour in behaviours) behaviour.enabled = !newValue;
  }
}
