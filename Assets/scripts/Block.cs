using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
}
