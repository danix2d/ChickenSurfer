using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Control", menuName = "Cube Surfer/Control", order = 0)]
public class Control : SOExpand {

    public GameObject prefab;
    public bool enableRigid;
    public bool stackCubes;
    public bool checkNumStack;
    public bool hasFinished;
    public bool canMove = true;
    public int cubesToStack;

    public override void ResetStats() 
    {
        canMove = true;
        enableRigid = false;
        stackCubes = false;
        checkNumStack = false;
        hasFinished = false;
        cubesToStack = 0;
    }
}
