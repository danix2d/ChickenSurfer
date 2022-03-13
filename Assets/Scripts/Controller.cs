using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameEvent happyChicken;
    public GameEvent gameOver;

    public Control controlSO;

    public GameObject character;
    public Transform Container;

    private Transform trans;
    private IEnumerator waitTime;

    private void Start() 
    {
        trans = transform;
        waitTime = WaitTime();
    }

    private void Update() 
    {
        if(controlSO.enableRigid)
        {
            EnableRigid();
        }

        if(controlSO.stackCubes)
        {
            StackCubes(controlSO.cubesToStack);
        }

        if(controlSO.checkNumStack)
        {
            CheckRemainingCubes();
        }
    }

    public void StackCubes(int num)
    {
        for (int i = 0; i < num; i++)
        {
            Instantiate(controlSO.prefab, Vector3.up*1000, Quaternion.identity, Container);
        }

        controlSO.stackCubes = false;
        controlSO.cubesToStack = 0;
        UpdatePos();
    }

    void UpdatePos()
    {
        float posY = Container.childCount - Container.position.y;

        foreach (Transform child in Container) {
            child.localPosition = new Vector3(0,posY,0);  
            posY -=1;  
        }
    }

    public void EnableRigid()
    {
        foreach (Transform child in Container) {
            Rigidbody rigid = child.gameObject.GetComponent<Rigidbody>();
            rigid.velocity = Vector3.zero;
            rigid.isKinematic = false;
        }

        controlSO.enableRigid = false;

        StopCoroutine(waitTime);
        StartCoroutine(waitTime);
    }

    public void DisableRigid()
    {
        foreach (Transform child in Container) {
            Rigidbody rigid = child.gameObject.GetComponent<Rigidbody>();
            rigid.velocity = Vector3.zero;
            rigid.isKinematic = true;
        }

        UpdatePos();
    }

    public void CheckRemainingCubes()
    {
        if(!controlSO.hasFinished && Container.childCount <= 1)
        {
            Debug.Log("GAME OVER");
            controlSO.checkNumStack = false;
            controlSO.canMove = false;
            gameOver.Raise();
        }

        if(controlSO.hasFinished && Container.childCount <= 1)
        {
            Debug.Log("LEVEL FINISHED");
            controlSO.checkNumStack = false;
            controlSO.canMove = false;
            happyChicken.Raise();
        }
    }


    private IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(2.5f);
        DisableRigid();
    }
}

