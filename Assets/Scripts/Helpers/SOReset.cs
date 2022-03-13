using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SOReset : MonoBehaviour
{
    public List<SOExpand> soList = new List<SOExpand>();

    void OnEnable()
    {
        for (int i = 0; i < soList.Count; i++)
        {
            soList[i].ResetStats();
        }    
    }

    void OnDisable()
    {
        for (int i = 0; i < soList.Count; i++)
        {
            soList[i].ResetStats();
        }    
    }
}
