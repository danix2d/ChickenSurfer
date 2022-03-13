using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class EventListener : Event
{
    public float waitForSeconds = 0;
    public GameEvent Event;
    public UnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDestroy()
    {
        Event.UnregisterListener(this);
    }

    public override void OnEventRaised(GameEvent pass)
    {
         Invoker.InvokeDelayed(RaiseEvent, waitForSeconds);
    }

    private void RaiseEvent()
    {
        Response.Invoke();
    }
}
