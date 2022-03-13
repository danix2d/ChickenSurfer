using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "Cube Surfer/Score", order = 0)]
public class Score : SOExpand {

    public int currentPoints;
    public int bestPoints;
    public int multiplier;

    public override void ResetStats() {
        currentPoints = 0;
        multiplier = 0;
    }
}
