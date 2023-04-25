using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int blockSize; // no need?
    long hashPrevBlock;
    long hashMerkleRoot; // is long long enough?
    int timestamp;
    int difficulty;
    int Nonce;
    List<Transaction> transctions = new List<Transaction>();


    public Block(){

    }
    
}
