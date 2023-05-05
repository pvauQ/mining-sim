using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : MonoBehaviour
{
    public BlockBeingMined toBeBlock;
    //public int nonce;
    public Blockchain chain;  // ref to chain
    public Node minerEntity; // or do we want to inherit node?


    public Miner(Blockchain chain, Node minerEntity){ //  mines only one block! after that dump it.
        this.chain = chain;
        this.minerEntity = minerEntity;
        this.toBeBlock = new BlockBeingMined(minerEntity, chain);      
    }

    public bool AddTrans(Transaction trans){ // call to add trans to block u are mining
        // is this stupid?
        toBeBlock.AddTrans(trans);
        return true;
    }

    public void Mine(int nonce){ // does mining, if finds block add it to chain, and "sends reward to miner
        Block prev = chain.getTop();
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
            //  saamme palkinnon --->
            reward(mined);
        }
    }
    private void  reward(Block mined){
        //TODO READ  the TRANSACTIONS for real!!
        minerEntity.receiveFunds(chain.reward);
    }


}