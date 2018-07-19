using System;
using UnityEngine;
using UnityEngine.Events;

public class GameEventArgsListener : MonoBehaviour
{
  public GameEventArgs Event;
  public GameEventArgsResponse Response = new GameEventArgsResponse();
  void OnEnable() { Event.RegisterListener(this); }
  void OnDisable() { Event.UnregisterListener(this); }
  public void OnEventRaised(object[] args) { Response.Invoke(args); }
}