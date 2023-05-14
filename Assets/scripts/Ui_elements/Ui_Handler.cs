using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Liitetään tämä peliobjektiksi jota käytetään jemmaamaan kaikki
// globaalit muuttujat ja viitteet
public class Ui_Handler : MonoBehaviour 
{
   // viiteitää muualle.
   public GameObject ui_pool;


    // tarvitaan mineria varten:
    public NMBlockChain chain;
    public NMNode playerNode; // players wallet
    public NMPool pool; //transactions are here before mining
    public NMMiner miner ; //  mineri instanssi.


    public ulong prev_hash_miner; // this is stupid. its here cause we want to have it after miner is dumped

    void Start()
    {
        Application.targetFrameRate = 60;

        this.chain = new NMBlockChain();
        this.playerNode = new NMNode(1); // osoite 1
        this.pool = new NMPool();
        // ^^ nämä pysyy samana koko pelin ajan.
        miner = new NMMiner(chain,playerNode,pool); //  we do miner here, so we have ref before first click.
        
        
    }



    //   methods that we can call from elements in ui
    // TODO  move this to player" object"
    public void OnMinerClick(){
        ulong[] mine_ret;

        try{
            mine_ret = miner.Mine();
            this.prev_hash_miner= mine_ret[0];
            if (mine_ret[1]== 1){ 
                ui_pool.GetComponent<Ui_Pool>().fieldClear();
                miner = new NMMiner(chain,playerNode,pool);
                //Debug.Log("block was found!");
            }
        }catch (System.Exception){
            ui_pool.GetComponent<Ui_Pool>().fieldClear();
            miner = new NMMiner(chain,playerNode,pool);
            //Debug.Log("Trying to mine old block");
        }


    }

}
