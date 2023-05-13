using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mining_agent : MonoBehaviour
{

    public GameObject main_handler;
    // get all these at Start() from main_handler
    NMBlockChain chain;
    NMNode agentNode; //agents wallet // if we have this as player node this could work as cpu/mining pool member??
    NMPool pool; 
    NMMiner miner;
    GameObject ui_pool;
    public int  frames_between_hashes= 360;
    int id;

    bool blockFoundLast = true; // to init
    // Start is called before the first frame update
    void Start()
    {
        this.id = Random.Range(0,int.MaxValue);

        this.agentNode = new NMNode(id);    
    }

    // Update is called once per frame
    void Update()
    {
        this.chain = main_handler.GetComponent<Ui_Handler>().chain;
        this.pool = main_handler.GetComponent<Ui_Handler>().pool;
        this.ui_pool = main_handler.GetComponent<Ui_Handler>().ui_pool;



        ulong[] mine_ret  = new ulong[2];
        if (blockFoundLast){
             this.blockFoundLast = false;
            this.miner = new NMMiner(chain,agentNode,pool);
            miner.toBeBlock.AddListOfTrans(pool.transactionsInPool); // just add all that exist in this moment.
        }
        if(Time.frameCount % frames_between_hashes == 1){
            try{
                mine_ret = miner.Mine();
                if (mine_ret[1]== 1){ 
                    this.blockFoundLast = true;
                    ui_pool.GetComponent<Ui_Pool>().fieldClear();
                }
            }catch (System.Exception){
                this.blockFoundLast = true;
                ui_pool.GetComponent<Ui_Pool>().fieldClear();
                //Debug.Log("Trying to mine old block");
            }
            
        }
        
    }
}
