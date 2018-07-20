using UnityEngine;

[CreateAssetMenu(menuName = "Game Management/Timer")]
public class Timer : ScriptableObject
{
  [SerializeField] FloatReference startTime;
  [SerializeField] FloatReference prepTime;
  public FloatVariable currentTime;
  public FloatVariable elapsedTime;

  void OnEnable() {
    currentTime.currentValue = 0;
    elapsedTime.currentValue = 0;
  }
}
