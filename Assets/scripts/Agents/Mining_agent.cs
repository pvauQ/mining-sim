using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// agentti, joita noi olla n+1 kun agentnode osoittaa pelaajaan toimii
// mining poolin jäsenenä/eli siis upgradena tms -> katso buy_one_upgrade
public class Mining_agent : MonoBehaviour
{

    public GameObject main_handler;

    NMBlockChain chain;
    public NMNode agentNode; //agents wallet // if we have this as player node this could work as cpu/mining pool member??
    NMPool pool; 
    NMMiner miner;
    GameObject ui_pool;
    public int  frames_between_hashes= 120;
    int id;

    // sörkitään nätä skriptissä joka luo  yksittäisen minerin.
    public bool InPLayersPool = false;
    public string type;
    public string desc;

    bool blockFoundLast = true;

    void Start()
    {

        // what is the execution order?, did we set variables before this this point?..>
        if (!InPLayersPool){
            this.agentNode = new NMNode(this.id = Random.Range(0,int.MaxValue));
        }
        else{
            this.agentNode = main_handler.GetComponent<Ui_Handler>().playerNode;
        }

    }

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
                    Debug.Log("mined for "+ agentNode.address);
                }
            }catch (System.Exception){
                this.blockFoundLast = true;
                ui_pool.GetComponent<Ui_Pool>().fieldClear();
                //Debug.Log("Trying to mine old block");
            }   
        }       
    }
}
