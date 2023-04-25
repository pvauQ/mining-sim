using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pool : MonoBehaviour
{
	 List<Transaction> transactionsInPool = new List<Transaction>();

	public bool addTransAction(Transaction trans){
		transactionsInPool.Add(trans);
		return true;
	}

	public Transaction getTransaction(int id){ // TODO  what do we want to use here
		// palautetaan tunnistetta vastaava Transactioni
		return null;
	}

	public bool removeTransactionFromPool(int id){ // TODO does this make sense
		return true;

	}
}
