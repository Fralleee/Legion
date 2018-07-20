using Fralle;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataUI : MonoBehaviour
{
  [SerializeField] GameData gameData;
  [SerializeField] Text elapsedTime;
  [SerializeField] Text roundTime;
  [SerializeField] Text countdown;
  [SerializeField] Text playerBuildings;
  [SerializeField] Text aiBuildings;

  void Update()
  {
    elapsedTime.text = "Elapsed Time: " + gameData.timer.elapsedTime.currentValue.Ceil().ToString() + "s";
    roundTime.text = "Round Time: " + gameData.timer.roundTime.currentValue.Ceil().ToString() + "s";
    countdown.text = "Countdown: " + gameData.timer.countdown.currentValue.Ceil().ToString() + "s";
    playerBuildings.text = "missing";
    aiBuildings.text = "missing";
  }
}