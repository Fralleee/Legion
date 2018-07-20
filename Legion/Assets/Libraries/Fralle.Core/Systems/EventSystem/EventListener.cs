using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventListener : MonoBehaviour
{
  public List<EventAndResponse> eventAndResponses = new List<EventAndResponse>();

  void OnEnable() { foreach (EventAndResponse eAndR in eventAndResponses) eAndR.gameEvent.Register(this); }
  void OnDisable() { foreach (EventAndResponse eAndR in eventAndResponses) eAndR.gameEvent.UnRegister(this); }

  [ContextMenu("Raise Events")]
  public void OnEventRaised(GameEvent passedEvent)
  {
    for (int i = eventAndResponses.Count - 1; i >= 0; i--)
      if (passedEvent == eventAndResponses[i].gameEvent) eventAndResponses[i].EventRaised();
  }
}

[Serializable]
public class EventAndResponse
{
  public string name;
  public GameEvent gameEvent;
  public UnityEvent response;

  public void EventRaised()
  {
    response.Invoke();
  }
}