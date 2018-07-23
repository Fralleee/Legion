using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
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
  public GameState state = GameState.Preparation;
  public IntVariable round;

  public GameRules rules;
  [SerializeField] List<GameRules> stateRules = new List<GameRules>();

  GameState defaultState = GameState.Preparation;

  void OnEnable()
  {
    state = defaultState;
    rules.CopyValues(stateRules[(int)state]);
  }

  public void ChangeState(GameState nextState)
  {
    state = nextState;
    rules.CopyValues(stateRules[(int)nextState]);
  }

  // Change this
  bool winCondition;

  void CheckConditions()
  {
    winCondition = true;
  }

  public void NextState()
  {
    switch (state)
    {
      case GameState.Waiting:
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
