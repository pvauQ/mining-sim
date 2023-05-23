using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Difficulty : MonoBehaviour {

    public Ui_Handler handler;

    private float targetTime = 3F; // Target average time for blocks to be mined in seconds, change to public to mess around with it in Unity
    private TimeSpan previousMiningTime; // Time it took to mine previous block
    private NMBlock previousBlock;
    private NMBlock currentBlock;
    public float meanSpeed = 3.00F;
    private List<double> timeList = new List<double>{};

    void Start() {
        previousBlock = handler.chain.blocks[0];
    }

    // Update is called once per frame
    void Update() {
        if (handler.chain.blocks.Count >= 3) {
            currentBlock = handler.chain.getTop();
            if (previousBlock != currentBlock) {
                SetPreviousMiningTime(previousBlock.timestamp);
                handler.chain.setDifficulty((ulong)GetBlockDifficulty());
                previousBlock = currentBlock;
            }
        }

    }

    public float GetBlockDifficulty() {
        float difficulty = handler.chain.difficulty;
        print("chain difficulty: " + handler.chain.difficulty);

        if (previousMiningTime.TotalSeconds > 0) {
            // TODO: Gaussian timeRatio around 1.00 (limit the change range, so that difficulty won't jump as wildly)
            float timeRatio = (float)Math.Sqrt(previousMiningTime.TotalSeconds / targetTime);

            UpdateMeanSpeed();
            float prevDiff = difficulty;
            difficulty *= timeRatio;
            print (prevDiff + " * " + timeRatio + " = " + difficulty + "(scaled diff:" + (difficulty/18446744073709551615) + ")");
        }
        return difficulty;
    }

    public void SetPreviousMiningTime(System.DateTime miningTime) {
        previousMiningTime = System.DateTime.Now - miningTime;
        timeList.Add(Math.Round(previousMiningTime.TotalSeconds, 2));
        print("Took " + Math.Round(previousMiningTime.TotalSeconds, 2) + "s to mine block #" + (handler.chain.blocks.Count - 2));
    }

    public void UpdateMeanSpeed() {
        meanSpeed = Mathf.Round((Time.time / timeList.Count) * 100f) / 100f;
    }
}
