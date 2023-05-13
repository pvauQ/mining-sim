using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is going to be script on every transaction that is visible,
// on click we want to  add to blockbeingMined
public class Ui_Transaction : MonoBehaviour
{
    public int id;
    public int fee;
    public GameObject main_handler;
    Vector3 scale;


    void Start(){
        main_handler =GameObject.Find("Main_handler");
        float multplier = fee*0.1f+1;
        this.scale = new Vector3(0.1f*multplier, 0.1f*multplier, 0.1f*multplier);
        transform.localScale = this.scale;
        //Debug.Log("synnyin "+ id);
    }

    void OnMouseDown(){
        Transaction trans = main_handler.GetComponent<Ui_Handler>().pool.getTransaction(this.id);
        //Debug.Log(trans.ToString());
        // lisätään to be blockkiin tämän ideetä vastaava transactio
        if (main_handler.GetComponent<Ui_Handler>().miner.getBlockBeingMined() != null){
            main_handler.GetComponent<Ui_Handler>().miner.getBlockBeingMined().AddTrans( trans);
            Destroy(gameObject);
        }
            
    }
}
