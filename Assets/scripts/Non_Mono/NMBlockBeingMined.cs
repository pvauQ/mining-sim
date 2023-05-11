using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

[System.Serializable]
public class NMBlockBeingMined
{

    public List<Transaction> transToInlclude ;
    public string hashMerkleRoot; 
    bool change = true;

    public NMBlockBeingMined(NMNode node ,NMBlockChain chain){
         this.transToInlclude =  new List<Transaction>();
         // add first transaction (reward to miner)
         Transaction reward = new Transaction(chain.reward, node.address , 0); // rewadin summa chainistä, osoite nodesta, ja syntyi tyhjästä(0)
         transToInlclude.Add(reward);
         // Call this here so we have intial markle
         this.hashMerkleRoot = this.GetHash();
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
