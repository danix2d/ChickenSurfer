using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnStart : MonoBehaviour
{
    public GameEvent gameEvent;

    void Start()
    {
        if(gameEvent != null)
        {
            gameEvent.Raise();
        }
    }
}
