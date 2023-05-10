using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Block;

public class Blockchain : MonoBehaviour
{
    // chain is made of blocks
    public List<Block> blocks ;
    public ulong difficulty = 0; //  	0 to 18,446,744,073,709,551,615
    public int reward; // reward to be avarded to miner;

    public GameObject blockInChainPrefab;
    public Transform blockLocation;

    public Blockchain(){
        this.blocks = new List<Block>();
        this.reward = 50;
        // genesis block
        //transaction for genesis
        List <Transaction> asd = new List<Transaction>();
        asd.Add(new Transaction(50,0,1));
    
        blocks.Add(new Block(0, "11", 1, 0, 0, 11,  asd)); // TODO  valid block!!
        setDifficulty(18_446_744_073_709_551_615/2);

    }
    

    public Block getTop(){
        return blocks[blocks.Count - 1];
    }
    public void setDifficulty(ulong diff){
        // we prob want multiply dif by x
        difficulty = diff;
    }
    
    public bool Add(Block block){
        blocks.Add(block);
        return true;
    }

    void Start() {
        this.blocks = new List<Block>();
        this.reward = 50;
        // genesis block
        //transaction for genesis
        List <Transaction> asd = new List<Transaction>();
        asd.Add(new Transaction(50,0,1));
    
        blocks.Add(new Block(0, "11", 1, 777, 0, 11,  asd)); // TODO  valid block!!
        setDifficulty(18_446_744_073_709_551_615/2);
    }

}
