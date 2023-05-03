using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public BlockBeingMined toBeBlock;
    //public int nonce;
    Blockchain chain;  // ref to chain
    Node minerEntity; // or do we want to inherit node?


    public Miner(Blockchain chain){
        chain = chain;
        toBeBlock = new BlockBeingMined();
    }

    public bool AddTrans(Transaction trans){
        // is this stupid?
        toBeBlock.AddTrans(trans);
        return true;
    }

    public void Mine(int nonce){
        Block prev = chain.getTop();
        string merkle = toBeBlock.GetHash();
/*
        string str  = nonce + merkle + prev.hash???

        uLong hash = Hasher.DoHashMd5Long(str)

        if (hash > chain.difficulty){
            // kokoamme lohkon 
            // lisäämme sen ketjuun
            //  saamme palkinnon --->
        */
        }

}