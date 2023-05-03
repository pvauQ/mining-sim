using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class BlockBeingMined : MonoBehaviour
{

    public List<Transaction> transToInlclude ;
    public string hashMerkleRoot; 
    bool change = false;

    public BlockBeingMined(){
         transToInlclude =  new List<Transaction>();
         //TODO
         // ensimmäinen on aina rewardi!!
         // otetaan node parametrinä?
         //transToInlclude.add() Transactio olio jossa palkinto minerille.
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
            str = str + trans.ToString();
        }
        hashMerkleRoot = Hasher.DoHashMD5(str);
        change = false;
        return hashMerkleRoot;
    }


    
}
