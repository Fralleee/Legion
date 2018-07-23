using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Waiting
//Preparation
//Live
//Ended

public class GameManager : MonoBehaviour
{
  [SerializeField] GameData gameData;
  StateMachine<GameState> fsm;
  public GameEvent stateChange;

  void ChangeState(GameState state)
  {
    Debug.Log("Changing state to: " + state.ToString());
    fsm.ChangeState(state);
    gameData.ChangeState(state);
    gameData.timer.ResetCountdown(gameData.rules.countdown);
    gameData.timer.ResetRoundTime();
    stateChange.Raise();
  }

  void Start()
  {
    fsm = StateMachine<GameState>.Initialize(this);
    ChangeState(gameData.state);
  }

  void Update()
  {
    SyncState();
    TimerTick();
  }

  void SyncState()
  {
    if (gameData.state != fsm.State) ChangeState(gameData.state);
  }

  void TimerTick()
  {
    if (gameData.rules.applyToElapsedTime) gameData.timer.Tick(Time.deltaTime);
    if (gameData.rules.countdown > 0) gameData.timer.CountdownTick(Time.deltaTime);
    if (gameData.rules.useRoundTimer) gameData.timer.RoundTick(Time.deltaTime);
  }
}
