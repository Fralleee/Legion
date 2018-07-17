using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
  public enum States { Default, Placing }
  States currentState = States.Default;

  [SerializeField] StringRangeVariable progress;
  [SerializeField] float castTime = 0.5f;
  [SerializeField] FloatVariable cooldown;
  [SerializeField] FloatReference gold;
  [SerializeField] FloatReference wood;
  [SerializeField] CurrentPlaceable currentPlaceable;

  void Start() { cooldown.currentValue = 0; }
  void Update()
  {
    if (cooldown.currentValue > 0) cooldown.currentValue = Mathf.Clamp(cooldown.currentValue - Time.deltaTime, 0, cooldown.defaultValue);
    if (currentPlaceable.placeable != null)
    {
      if (Input.GetMouseButtonDown(0))
      {
        progress.text = "BUILDING!";
        progress.minValue = 0f;
        progress.maxValue = castTime;
        progress.value = 0f;
      }
      else if (Input.GetMouseButton(0) && currentPlaceable.placeable.CanBuild())
      {
        progress.value += Time.deltaTime;
        if (progress.value >= progress.maxValue)
        {
          currentPlaceable.placeable.Build();
          progress.value = 0f;
          cooldown.currentValue = cooldown.defaultValue;
        }
      }

      else if (Input.GetMouseButtonUp(0)) progress.value = 0f;
      else if (Input.GetMouseButtonDown(1))
      {
        progress.value = 0f;
        currentPlaceable.placeable.Cancel();
        currentPlaceable.DeActivate();
      }
    }


  }
}
