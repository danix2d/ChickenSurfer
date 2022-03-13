using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameEvent : ScriptableObject
{

    private readonly List<Event> eventListeners = new List<Event>();

    public void Raise()
    {
        for(int i = eventListeners.Count -1; i >= 0; i--)
        {
            eventListeners[i].OnEventRaised(this);
            Debug.Log("LISTENER ----> " + eventListeners[i].name + " <---- EVENT ----> " + this.name);
        }
    }

    public void RegisterListener(Event listener)
    {
        if (!eventListeners.Contains(listener))
        {
            eventListeners.Add(listener);
        }

    }

    public void UnregisterListener(Event listener)
    {
        if (eventListeners.Contains(listener))
        {
            eventListeners.Remove(listener);
        }
    }
}