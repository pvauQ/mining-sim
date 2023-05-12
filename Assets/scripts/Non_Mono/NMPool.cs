using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class NMPool
{
	 public List<Transaction> transactionsInPool ;
	 List<Transaction> trans_not_retuned;  // not the smatest way to do this.

	public NMPool(){
		this.transactionsInPool =  new List<Transaction>();
		this.trans_not_retuned =  new List<Transaction>();
	}
	public bool addTransAction(Transaction trans){
		this.transactionsInPool.Add(trans);
		this.trans_not_retuned.Add(trans);
		return true;
	}

	public Transaction getTransaction(int id){
		Transaction trans = transactionsInPool.First(obj => obj.id == id);
		return trans;

	}
	public List<Transaction> getNewTrans(){ // to be used in ui and only in one place, breaks otherwise
		List<Transaction> tmp = new List<Transaction>(trans_not_retuned);
		trans_not_retuned.Clear();
		return tmp;
	}

	public bool removeTransactionFromPool(int id){ //  does this make sense
		return true;
	}
	public bool removeListOfTransFromPool(List<Transaction> toRemove){ // to be used when block is mined
		transactionsInPool.RemoveAll(item =>toRemove.Contains(item));
		trans_not_retuned.RemoveAll(item =>toRemove.Contains(item));
		return true;
	}
}
