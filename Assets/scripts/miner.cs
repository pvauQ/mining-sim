using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Miner : MonoBehaviour
{
    public BlockBeingMined toBeBlock;
    //public int nonce;
    public Blockchain chain;  // ref to chain
    public Node minerEntity; 
    Block refBlock; // we use this to determine if new block was mined.
    Pool pool;

    public Miner(Blockchain chain, Node minerEntity, Pool pool){ //  mines only one block! after that dump it.
        this.pool = pool;
        this.chain = chain;
        this.minerEntity = minerEntity;
        this.toBeBlock = new BlockBeingMined(minerEntity, chain);
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
        Block prev = chain.getTop();
        ulong[] ret;
        if (prev != refBlock){
            throw new Exception("new block in chain! dump me");
        }
        string merkle = toBeBlock.GetHash();
        string str  = nonce + merkle + prev.hashThisBlock;
        ulong hash = Hasher.DoHashMd5Long(str);

        if (hash < chain.difficulty){
            // kokoamme lohkon 
            Block mined = new Block(
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
    private void  reward(Block mined){
        //TODO READ  the TRANSACTIONS for real!!
        minerEntity.receiveFunds(chain.reward);
    }


}