using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour {
    public GameObject main_handler;

    public Text textToDisplay;
    public Text difficultyText;
    public Text nonceText;
    public Text merkleText;
    public Text generatedHash;
    public Text meanBlockMiningSpeed;

    public Difficulty difficulty;
    public float playerCurrency = 0F;

    void Start() {
        //print(block.hashPrevBlock + ", " + block.hashMerkleRoot + ", " + block.timestamp + ", " + block.difficulty);

    }

    // Update is called once per frame
    void Update() {
        textToDisplay.text = "Coins: " + main_handler.GetComponent<Ui_Handler>().playerNode.funds ;
        difficultyText.text = "Difficulty: " +main_handler.GetComponent<Ui_Handler>().chain.difficulty;
        nonceText.text = "Nonce: " + main_handler.GetComponent<Ui_Handler>().miner.nonce;
        merkleText.text = "Merkle: " + main_handler.GetComponent<Ui_Handler>().miner.toBeBlock.hashMerkleRoot;
        generatedHash.text = "+"  + main_handler.GetComponent<Ui_Handler>().prev_hash_miner;
        meanBlockMiningSpeed.text = difficulty.meanSpeed + " s/block";
    }
}
