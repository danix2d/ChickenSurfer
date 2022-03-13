using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishBonus : MonoBehaviour
{
    public GameEvent finish;
    public Control control;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            control.hasFinished = true;
            control.checkNumStack = false;
            control.canMove = false;
            finish.Raise();
        }
    }
}