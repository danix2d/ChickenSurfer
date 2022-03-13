using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public Score score;

    private int bestScore;

    private void Awake() {
        score.bestPoints = PlayerPrefs.GetInt("BestScore");
    }

    private void OnDisable() {
        PlayerPrefs.SetInt("BestScore", score.bestPoints);
        PlayerPrefs.Save();
    }

    private void OnApplicationPause() {
        PlayerPrefs.SetInt("BestScore", score.bestPoints);
        PlayerPrefs.Save();
    }
}
