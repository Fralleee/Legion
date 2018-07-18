using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Events/Game Event")]
public class GameEventArgs : ScriptableObject
{
  public List<GameEventArgsListener> listeners = new List<GameEventArgsListener>();

  public void Raise()
  {
    for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(null);
  }

  public void Raise(params object[] args)
  {
    for (int i = listeners.Count - 1; i >= 0; i--) listeners[i].OnEventRaised(args);
  }

  public void RegisterListener(GameEventArgsListener listener)
  {
    if (listeners.Contains(listener)) return;
    listeners.Add(listener);
  }
  public void UnregisterListener(GameEventArgsListener listener)
  {
    if (!listeners.Contains(listener)) return;
    listeners.Remove(listener);
  }
}
