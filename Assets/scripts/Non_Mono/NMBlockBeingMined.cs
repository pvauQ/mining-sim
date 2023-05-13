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
    public int num_of_trans;

    public NMBlockBeingMined(NMNode node ,NMBlockChain chain){
         this.transToInlclude =  new List<Transaction>();
         // add first transaction (reward to miner)
         Transaction reward = new Transaction(chain.reward, node.address , 0); // rewadin summa chainistä, osoite nodesta, ja syntyi tyhjästä(0)
         this.transToInlclude.Add(reward);
         // Call this here so we have intial markle
         this.hashMerkleRoot = this.GetHash();
    }

    public bool AddTrans(Transaction trans){
        this.transToInlclude.Add(trans);
        change = true;
        GetHash();
        return true;
    }
    public bool AddListOfTrans(List<Transaction> trans){
        this.transToInlclude.AddRange(trans);
        change = true;
        GetHash();
        return true;
    } 



    public string GetHash(){
    // returns hash and stores in in hashMerkleRoot
    num_of_trans = this.transToInlclude.Count;
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
