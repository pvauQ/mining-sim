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
        hashPrevBlock = hashPrevBlock;
        hashMerkleRoot = merkle;
        timestamp = timestamp;
        difficulty = difficulty;
        nonce = nonce;
        hashThisBlock = hashThisBlock;
        transactions = transactions;

    }
    
}
