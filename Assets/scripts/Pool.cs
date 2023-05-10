using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	 List<Transaction> transactionsInPool ;

	public Pool(){
		this.transactionsInPool =  new List<Transaction>();

	}
	public bool addTransAction(Transaction trans){
		transactionsInPool.Add(trans);
		return true;
	}

	public Transaction getTransaction(int id){ // TODO  what do we want to use here
		// palautetaan tunnistetta vastaava Transactioni
		return null;
	}

	public bool removeTransactionFromPool(int id){ //  does this make sense
		return true;
	}
	public bool removeListOfTransFromPool(List<Transaction> toRemove){ // to be used when block is mined
		transactionsInPool.RemoveAll(item =>toRemove.Contains(item));
		return true;
	}
}
