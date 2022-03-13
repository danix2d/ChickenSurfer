using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UI_Collect : MonoBehaviour
{
    public Score score;
    public TMP_Text statsTxt;
    
    private void Start() 
    {
        UpdateScore();
    }

    public void UpdateScore()
    {
        statsTxt.text = score.bestPoints.ToString();
    }

    public void EndPoints()
    {
        score.bestPoints = score.bestPoints - score.currentPoints + score.currentPoints * score.multiplier;
        UpdateScore();
    }
}
