using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This is used to create random hashes
*/

public class Block : MonoBehaviour
{
    //int blockSize; // no need?
    public ulong hashPrevBlock;
    public string hashMerkleRoot; // is long long enough?
    public int timestamp;
    public ulong difficulty;
    public int nonce;
    public ulong hashThisBlock;
    public List<Transaction> transactions;


    public Blockchain blockChain;
    public Miner miner;


    public Block( ulong hashPrevBlock, string merkle, int timestamp,
                ulong difficulty, int nonce, ulong hashThisBlock,List<Transaction> trans){
        this.hashPrevBlock = hashPrevBlock;
        this.hashMerkleRoot = merkle;
        this.timestamp = timestamp;
        this.difficulty = difficulty;
        this.nonce = nonce;
        this.hashThisBlock = hashThisBlock;
        this.transactions = trans;

    }

    public Block(ulong difficulty) {
        this.difficulty = difficulty;
    }

    void Start() {
        FindObjectOfType<PlayerController>().onCookieClick += newHash;
        hashPrevBlock = blockChain.getTop().hashPrevBlock;
        hashMerkleRoot = blockChain.getTop().hashMerkleRoot;
        timestamp = blockChain.getTop().timestamp;
        difficulty = blockChain.getTop().difficulty;
        nonce = blockChain.getTop().nonce;
        hashThisBlock = blockChain.getTop().hashThisBlock;
        transactions = blockChain.getTop().transactions;
    }

    void newHash() {
        hashThisBlock = miner.Mine(nonce)[0];
        print("hash result: " + miner.Mine(nonce)[0] + ", " + miner.Mine(nonce)[1] + "(1=mined,0=not mined)");
        increaseNonce();
    }

    void increaseNonce() {
        nonce++;
        print("increasing nonce: " + nonce);
    }
    
}
