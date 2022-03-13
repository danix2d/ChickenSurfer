using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{
    public Score score;
    public GameObject multiplierVFX;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            score.multiplier ++;
            Instantiate(multiplierVFX,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
