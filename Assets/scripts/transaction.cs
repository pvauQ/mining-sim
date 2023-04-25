using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transaction : MonoBehaviour
{
	float fee;
	long out_address;
	long in_address;
	long id; // for game purposes not a real thing



	public override string ToString(){ // to be used for merkleroot
		return $"fee:{fee}, from{in_address}, to {out_address}, with {id}";
	}
}
