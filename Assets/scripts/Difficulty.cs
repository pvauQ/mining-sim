using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Difficulty : MonoBehaviour {

    public Ui_Handler handler;

    public float targetTime = 3F; // Target average time for blocks to be mined in seconds, change to public to mess around with it in Unity
    public int lastX = 10;
    private TimeSpan previousMiningTime; // Time it took to mine previous block
    private NMBlock previousBlock;
    private NMBlock currentBlock;
    public float meanSpeed = 3.00F; // mean of latest X(amount) mined block's mining time in seconds 
    private List<double> timeList = new List<double>{};

    void Start() {
        previousBlock = handler.chain.blocks[0];
    }

    // Update is called once per frame
    void Update() {
        if (handler.chain.blocks.Count >= 2) {
            currentBlock = handler.chain.getTop();
            if (previousBlock != currentBlock) {
                SetPreviousMiningTime(previousBlock.timestamp);
                handler.chain.setDifficulty(GetBlockDifficulty());
                UpdateMeanSpeed(); // A new block was mined, so time to update meanSpeed
                previousBlock = currentBlock;
            }
        }

    }

    public ulong GetBlockDifficulty() {
        ulong difficulty = handler.chain.difficulty;

        if (previousMiningTime.TotalSeconds > 0) {
            // timeRatio = multiplier to change current difficulty with. 
            // If took longer than targetTime: higher value. If took less: lower value
            // Square root to smoothen the change ( 0 < values < 1 -> closer to 1. Values > 1: brought closer to 1)
            float timeRatio = (float)Math.Sqrt(previousMiningTime.TotalSeconds / targetTime); // try meanSpeed vs previousMiningTime.TotalSeconds
            float prevDiff = difficulty;

            if (timeRatio*difficulty >= ulong.MaxValue)
                difficulty = ulong.MaxValue;
            else
                difficulty = (ulong)Math.Floor(difficulty * timeRatio);

            double divisor = 18446744073709551615.0;
            double result = difficulty/divisor;
            print (prevDiff + " * " + timeRatio + " = " + difficulty + "(scaled diff:" + result + ")");
        }
        return difficulty;
    }

    public void SetPreviousMiningTime(System.DateTime miningTime) {
        previousMiningTime = System.DateTime.Now - miningTime;
        timeList.Add(Math.Round(previousMiningTime.TotalSeconds, 2));
        print("Took " + Math.Round(previousMiningTime.TotalSeconds, 2) + "s to mine block #" + (handler.chain.blocks.Count - 1));
    }

    public void UpdateMeanSpeed()
    {
        int count = Mathf.Min(timeList.Count, lastX); // Get the minimum value between the count of elements and 10
        int startIndex = timeList.Count - count; // Calculate the starting index for the latest 10 elements

        float sum = 0f;
        for (int i = startIndex; i < timeList.Count; i++)
        {
            sum += (float)timeList[i];
        }

        meanSpeed = Mathf.Round((sum / count) * 100f) / 100f;
    }

}
