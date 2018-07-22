using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates
{
  Preparation,
  Live,
  Ended,
  Waiting,
}

[CreateAssetMenu(menuName = "Game Management/Game Data")]
public class GameData : ScriptableObject
{
  public Timer timer;
  public GameStates state = GameStates.Preparation;
  public IntVariable round;

  GameStates defaultState = GameStates.Preparation;

  void OnEnable() { state = defaultState; }

  // Change this
  bool winCondition;

  // Player buildings
  // Scores
  // Stats
  // Unit info
  // Conditions?
  void CheckConditions()
  {
    winCondition = true;
  }
  
  public void NextState()
  {
    switch (state)
    {
      case GameStates.Waiting:
        state = GameStates.Preparation;
        break;
      case GameStates.Preparation:
        state = GameStates.Live;
        break;
      case GameStates.Live:
        if (winCondition) state = GameStates.Ended;
        else state = GameStates.Preparation;
        break;
      case GameStates.Ended:
        // Back to menu
        break;
      default:
        Debug.Log("Something went wrong when changing to next state.");
        Debug.Log("Current State: " + state);
        break;
    }
  }

  public bool isWaiting { get { return state == GameStates.Waiting; } }
  public bool isPreparation { get { return state == GameStates.Preparation; } }
  public bool isLive { get { return state == GameStates.Live; } }
  public bool isEnded { get { return state == GameStates.Ended; } }

  public void Victory()
  {
    
  }

  public void Defeat()
  {

  }
}
