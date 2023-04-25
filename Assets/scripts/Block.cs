using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int blocSize;
    long PrevBlock;
    long merkleRoot; // is long long enough?
    int timestamp;
    int difficulty;
    int Nonce;
    Transaction[] transctions; // first is always the revard


    public Block(){

    }
    
}
