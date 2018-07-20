using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
  Waiting,
  MatchStart,
  Preparation,
  Live,
  Ended,
}

[CreateAssetMenu(menuName = "Game Management/Game Data")]
public class GameData : ScriptableObject
{
  [SerializeField] Timer timer;
  [SerializeField] GameState state;
  [SerializeField] IntVariable round;
  GameState defaultState = GameState.Waiting;

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
      case GameState.Waiting:
        state = GameState.MatchStart;
        break;
      case GameState.MatchStart:
        state = GameState.Preparation;
        break;
      case GameState.Preparation:
        state = GameState.Live;
        break;
      case GameState.Live:
        if (winCondition) state = GameState.Ended;
        else state = GameState.Preparation;
        break;
      case GameState.Ended:
        // Back to menu
        break;
      default:
        Debug.Log("Something went wrong when changing to next state.");
        Debug.Log("Current State: " + state);
        break;
    }
  }

  public void Victory()
  {
    
  }

  public void Defeat()
  {

  }
}
