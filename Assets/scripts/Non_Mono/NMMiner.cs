using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NMMiner :ScriptableObject
{
    public NMBlockBeingMined toBeBlock;
    //public int nonce;
    public NMBlockChain chain;  // ref to chain
    public NMNode minerEntity; 
    NMBlock refBlock; // we use this to determine if new block was mined.
    public NMPool pool;


    public NMMiner(NMBlockChain chain, NMNode minerEntity, NMPool pool){ //  mines only one block! after that dump it.
        this.pool = pool;
        this.chain = chain;
        this.minerEntity = minerEntity;
        this.toBeBlock = new NMBlockBeingMined(minerEntity, chain);
        this.refBlock = chain.getTop();
    }

    public bool AddTrans(Transaction trans){ // call to add trans to block u are mining
        // is this stupid?
        toBeBlock.AddTrans(trans);
        return true;
    }

    // does mining, if finds block add it to chain, and "sends reward to miner
    // return array of 2 ulongs, first is a hash, and second is 1 if block was mined and 0 if no block is mined
    // throws Execption if block if we are mining old block.
    public ulong[] Mine(int nonce){ // does mining, if finds block add it to chain, and "sends reward to miner
        NMBlock prev = chain.getTop();
        ulong[] ret;
        if (prev != refBlock){
            throw new Exception("new block in chain! dump me");
        }
        string merkle = toBeBlock.GetHash();
        string str  = nonce + merkle + prev.hashThisBlock;
        ulong hash = Hasher.DoHashMd5Long(str);

        if (hash < chain.difficulty){
            // kokoamme lohkon 
            NMBlock mined = new NMBlock(
                prev.hashThisBlock,
                merkle ,
                Time.frameCount, //frame number from unity engine
                chain.difficulty,
                nonce,
                hash,
                toBeBlock.transToInlclude);
            // lisäämme sen ketjuun
            chain.Add(mined);
            // poistamme sisälletyt transactiot poolista-->
            pool.removeListOfTransFromPool(toBeBlock.transToInlclude);

            //  saamme palkinnon --->
            reward(mined);
            ret =  new ulong[]{hash,1};
            return ret;
        }
        ret =  new ulong[]{hash,0};
        return ret;
    }
    // sums the fees of all trans in this block, calls method from provided miner to receive the fees.
    // return rewarded amount
    private int reward(NMBlock mined){
        //  transactions in block, first is reward and later ones have a fee.
        int reward = 0;
        foreach (Transaction trans in mined.transactions){
            reward = reward+trans.fee;
        }
        minerEntity.receiveFunds(reward);
        return reward;
    }


}