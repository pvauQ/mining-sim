using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using NMBlock;

public class NMBlockChain : ScriptableObject
{
    // chain is made of blocks
    public List<NMBlock> blocks ;
    public ulong difficulty = 0; //  	0 to 18,446,744,073,709,551,615
    public int reward; // reward to be avarded to miner;

    public GameObject blockInChainPrefab;
    public Transform blockLocation;

    public NMBlockChain(){
        this.blocks = new List<NMBlock>();
        this.reward = 50;
        // genesis block
        //transaction for genesis
        List <Transaction> asd = new List<Transaction>();
        asd.Add(new Transaction(50,0,1));
    
        blocks.Add(new NMBlock(0, "11", 1, 0, 0, 11,  asd)); // TODO  valid block!!
        setDifficulty(18_446_744_073_709_551_615/2);

    }
    

    public NMBlock getTop(){
        return blocks[blocks.Count - 1];
    }
    public void setDifficulty(ulong diff){
        // we prob want multiply dif by x
        difficulty = diff;
    }
    
    public bool Add(NMBlock block){
        blocks.Add(block);
        return true;
    }

}
