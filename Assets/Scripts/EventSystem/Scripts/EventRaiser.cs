using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventRaiser : MonoBehaviour
{
    public float waitTime;
    public GameEvent gameEvent;

    [RuntimeInitializeOnLoadMethod]
    void OnEnable()
    {
        Invoke();
    }

    private void Invoke()
    {
        Invoker.InvokeDelayed(RaiseEvent,waitTime);
    }

    private void RaiseEvent()
    {
        gameEvent.Raise();
    }
}
