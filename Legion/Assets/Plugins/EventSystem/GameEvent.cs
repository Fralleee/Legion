using System.Collections.Generic;
using UnityEngine;

namespace Fralle
{
  [CreateAssetMenu(menuName = "Match/Utils/Game Event")]
  public class GameEvent : ScriptableObject
  {
    private List<EventListener> eventListeners = new List<EventListener>();
    public void Raise() { for (int i = eventListeners.Count - 1; i >= 0; i--) eventListeners[i].OnEventRaised(this); }
    public void Register(EventListener passedEvent) { eventListeners.AddIfUnique(passedEvent); }
    public void UnRegister(EventListener passedEvent) { eventListeners.RemoveIfExists(passedEvent); }
  }
}