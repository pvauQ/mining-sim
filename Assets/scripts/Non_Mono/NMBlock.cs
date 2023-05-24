using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This is used to create random hashes
*/

//[System.Serializable]
public class NMBlock
{
    //int blockSize; // no need?
    public ulong hashPrevBlock;
    public string hashMerkleRoot; // is long long enough?
    public System.DateTime timestamp;
    public ulong difficulty;
    public int nonce;
    public ulong hashThisBlock;
    public List<Transaction> transactions;


    public NMBlockChain blockChain;
    public NMMiner miner;


    public NMBlock( ulong hashPrevBlock, string merkle, System.DateTime timestamp,
                ulong difficulty, int nonce, ulong hashThisBlock,List<Transaction> trans){
        this.hashPrevBlock = hashPrevBlock;
        this.hashMerkleRoot = merkle;
        this.timestamp = timestamp;
        this.difficulty = difficulty;
        this.nonce = nonce;
        this.hashThisBlock = hashThisBlock;
        this.transactions = trans;

    }

    public NMBlock(ulong difficulty, string merkle, long timestamp) {
        this.difficulty = difficulty;
    }
    	public override string ToString(){ // to be used for merkleroot
		return $"hash: {hashThisBlock}\n  merkleroot: {hashMerkleRoot} \n number of transactions: {transactions.Count}";
	}
}
