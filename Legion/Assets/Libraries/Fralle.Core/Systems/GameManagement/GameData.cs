using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
  Start,
  PrepTime,
  Live,
  End,
}

[CreateAssetMenu(menuName = "Game Management/Game Data")]
public class GameData : ScriptableObject
{
  [SerializeField] Timer timer;
  [SerializeField] GameState state;
  GameState defaultState = GameState.Start;

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
      case GameState.Start:
        state = GameState.PrepTime;
        break;
      case GameState.PrepTime:
        state = GameState.Live;
        break;
      case GameState.Live:
        if (winCondition) state = GameState.End;
        else state = GameState.PrepTime;
        break;
      case GameState.End:
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
