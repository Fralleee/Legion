using UnityEngine;

[CreateAssetMenu(menuName = "Game Management/Timer")]
public class Timer : ScriptableObject
{
  [SerializeField] FloatReference startTime;
  [SerializeField] FloatReference prepTime;
  public FloatVariable roundTime;
  public FloatVariable elapsedTime;
  public FloatVariable countdown;

  void OnEnable() {
    roundTime.currentValue = 0;
    elapsedTime.currentValue = 0;
  }

  public void Tick(float time) { elapsedTime.currentValue += time; }
  public void RoundTick(float time) { roundTime.currentValue += time; }
  public void CountdownTick(float time) { countdown.currentValue -= time; }
  public bool CountdownReached { get { return countdown.currentValue <= 0;  } }
  public void ResetCountdown(float countdownTime) { countdown.currentValue = countdownTime; }
  public void ResetRoundTime() { roundTime.currentValue = 0f; }
  
}
