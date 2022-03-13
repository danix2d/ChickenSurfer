using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{
    public Score score;
    public GameEvent hitPoint;
    public GameObject crystalVFX;
    
    private bool hasHit;

    private void OnTriggerEnter(Collider other) 
    {
        if(!hasHit && other.gameObject.CompareTag("Player"))
        {
            hasHit = true;
            score.currentPoints ++;
            score.bestPoints ++;
            Instantiate(crystalVFX,transform.position,Quaternion.identity);
            hitPoint.Raise();
            Destroy(gameObject);
        }
    }
}
