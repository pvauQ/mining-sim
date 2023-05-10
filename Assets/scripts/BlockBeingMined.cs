using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class BlockBeingMined : MonoBehaviour
{

    public List<Transaction> transToInlclude ;
    public string hashMerkleRoot; 
    bool change = false;

    public BlockBeingMined(Node node ,Blockchain chain){
         this.transToInlclude =  new List<Transaction>();
         // add first transaction (reward to miner)
         Transaction reward = new Transaction(chain.reward, node.address , 0); // rewadin summa chainistä, osoite nodesta, ja syntyi tyhjästä(0)
         transToInlclude.Add(reward);
    }

    public bool AddTrans(Transaction trans){
        transToInlclude.Add(trans);
        change = true;
        return true;
    } 


    public string GetHash(){
    // returns hash and stores in in hashMerkleRoot
        if (change == false){
            return hashMerkleRoot; // if  no change no need to do hash
        }
        string str = "";
        foreach(Transaction trans in  transToInlclude){ 
            str = str + trans.ToString(); // Fix. Only last transaction will be present this way because its a foreach loop
        }
        hashMerkleRoot = Hasher.DoHashMD5(str);
        change = false;
        return hashMerkleRoot;
    }


    
}
