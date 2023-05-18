using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NMNode
{
    public int funds;
    public int address;
    NMPool pool;

    public NMNode(int address){
    this.funds = 20;
    this.address = address;
    }
    
    public NMNode(int address,NMPool pool){
    this.funds = 20;
    this.address = address;
    this.pool = pool;
    }

    public int receiveFunds(int amount ){
        // naming of this might be litle weird,
        // kind of implies that node goes and reads from from chain
        // like the real deal
        funds = funds+amount;
        return funds;
    }
    public void sendFunds(int amount, int address){//this is realy sad
        this.funds -= amount;
        this.pool.addTransAction(new Transaction(1,amount,100,1)); 

    }


}