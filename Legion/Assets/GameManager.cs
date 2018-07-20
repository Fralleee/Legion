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
  StateMachine<GameStates> fsm;

  void ChangeState(GameStates state)
  {
    fsm.ChangeState(state);
    gameData.state = state;
  }

  void Start()
  {
    fsm = StateMachine<GameStates>.Initialize(this);
    ChangeState(GameStates.Waiting);
  }

  void Update()
  {
    if (gameData.state != fsm.State) fsm.ChangeState(gameData.state);
    if (fsm.State != GameStates.Waiting)
    {
      Debug.Log("Waiting state");
      gameData.timer.Tick(Time.deltaTime);
    }
  }

  void Preparation_Enter() { gameData.timer.ResetCountdown(); }
  void Preparation_Update()
  {
    gameData.timer.CountdownTick(Time.deltaTime);
    if (gameData.timer.CountdownReached) ChangeState(GameStates.Live);
  }


  void Live_Update() { gameData.timer.RoundTick(Time.deltaTime); }
  void Live_Exit() { gameData.timer.ResetRoundTime(); }
}
