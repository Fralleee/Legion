﻿using UnityEngine;

[CreateAssetMenu(menuName = "Match/Data/Game Rules")]
public class GameRules : ScriptableObject
{
  public GameState gameState;
  public Blocker blocker;

  [Header("Timer settings")]
  public bool applyToElapsedTime;
  public bool useRoundTimer;
  public float countdown;

  public void CopyValues(GameRules data)
  {
    gameState = data.gameState;
    blocker = data.blocker;
    applyToElapsedTime = data.applyToElapsedTime;
    useRoundTimer = data.useRoundTimer;
    countdown = data.countdown;
  }
}
