using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Transaction
{
	public int fee;
	int out_address;
	int in_address;
	int id; // for game purposes not a real thing

	public Transaction(int fee, int out_address, int in_address){
		System.Random rnd = new System.Random();
		this.id = rnd.Next();// eheh
		this.fee = fee;
		this.in_address = in_address;
		this.out_address = out_address;
	}

	public override string ToString(){ // to be used for merkleroot
		return $"fee:{fee}, from{in_address}, to {out_address}, with {id}";
	}
}
