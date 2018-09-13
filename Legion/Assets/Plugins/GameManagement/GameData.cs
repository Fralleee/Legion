using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
  Preparation,
  Live,
  Ended,
  Waiting,
}

[CreateAssetMenu(menuName = "Match/Data/Game Data")]
public class GameData : ScriptableObject
{
  public Timer timer;
  public GameState state = GameState.Preparation;
  public IntVariable round;

  public GameRules rules;
  [SerializeField] List<GameRules> rulesFromState = new List<GameRules>();

  public TeamData blueTeamData;
  public TeamData orangeTeamData;

  GameState defaultState = GameState.Preparation;

  void OnEnable()
  {
    state = defaultState;
    rules.CopyValues(rulesFromState[(int)state]);
  }

  public void SetRulesFromState(GameState nextState)
  {
    state = nextState;
    rules.CopyValues(rulesFromState[(int)nextState]);
  }

  // Change this
  bool winCondition;

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
        state = winCondition ? GameState.Ended : GameState.Preparation;
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
