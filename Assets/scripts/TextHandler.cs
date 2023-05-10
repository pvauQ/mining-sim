using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextHandler : MonoBehaviour {

    public Text textToDisplay;
    public Text difficultyText;
    public Text nonceText;
    public Text merkleText;
    public Text generatedHash;
    public Blockchain blockChain;
    public Block block;
    public float playerCurrency = 0F;

    void Start() {
        print(block.hashPrevBlock + ", " + block.hashMerkleRoot + ", " + block.timestamp + ", " + block.difficulty);
    }

    // Update is called once per frame
    void Update() {
        textToDisplay.text = "Coins: " + playerCurrency.ToString();
        difficultyText.text = "Difficulty: " + block.difficulty;
        nonceText.text = "Nonce: " + block.nonce;
        merkleText.text = "Merkle: " + block.hashMerkleRoot;
        generatedHash.text = "+" + block.hashThisBlock.ToString();
    }
}
