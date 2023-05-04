using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public int funds;
    public int address;

    public Node(int address){
    funds = 0;
    address = address;
    }

    public int receiveFunds(int amount ){
        // naming of this might be litle weird,
        // kind of implies that node goes and reads from from chain
        // like the real deal
        funds = funds+amount;
        return funds;
    }


}