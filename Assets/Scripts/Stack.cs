using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stack : MonoBehaviour
{
    public Control control;
    public GameEvent hitStack;
    public int cubes;

    void Start()
    {
        cubes = transform.childCount;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            control.cubesToStack = cubes;
            control.stackCubes = true;
            hitStack.Raise();
            Destroy(gameObject);
        }
    }
}
