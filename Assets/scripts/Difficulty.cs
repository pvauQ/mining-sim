using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour {

    public float targetTime = 30F; // Target average time for blocks to be mined in seconds
    public float baseDifficulty = 18_446_744_073_709_551_615/2f;
    private float previousMiningTime; // Time it took to mine previous block

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public float GetBlockDifficulty() {
        float difficulty = baseDifficulty;

        if (previousMiningTime > 0) {
            float timeRatio = previousMiningTime / targetTime;
            difficulty *= timeRatio;
        }

        return difficulty;
    }

    public void SetPreviousMiningTime(float miningTime) {
        previousMiningTime = miningTime;
    }
}
