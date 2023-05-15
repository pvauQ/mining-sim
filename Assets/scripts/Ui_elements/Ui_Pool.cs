using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui_Pool : MonoBehaviour
{

    public GameObject main_handler;
    public GameObject trans_prefab;
    public GameObject tip_prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        List<Transaction> new_trans = main_handler.GetComponent<Ui_Handler>().pool.getNewTrans();
        
        foreach (Transaction trans in new_trans){
            spawn(trans);
        }
    }

    // after block is mined clear the field and start with trans left in pool,
    // done this way so  it does not matter who /what mined the block
    public void fieldClear(){
        foreach (Transform child in transform) {
            GameObject.Destroy(child.gameObject);
        }


        List<Transaction> transactions = main_handler.GetComponent<Ui_Handler>().pool.transactionsInPool;
        foreach (Transaction trans in transactions){
            spawn(trans);
        }
    }

    private void spawn(Transaction trans){

            Vector2 pos_offset = Random.insideUnitCircle * 2;
            Vector3 pos = new Vector3(transform.position.x + pos_offset.x, transform.position.y+pos_offset.y, transform.position.z);
            GameObject asd = Instantiate(trans_prefab ,pos, transform.rotation, transform);
            asd.GetComponent<Ui_Transaction>().tooltip_prefab = this.tip_prefab;
            asd.GetComponent<Ui_Transaction>().fee = trans.fee;
            asd.GetComponent<Ui_Transaction>().id = trans.id;

    }
}
