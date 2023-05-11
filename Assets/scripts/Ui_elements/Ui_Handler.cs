using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Liitetään tämä peliobjektiksi jota käytetään jemmaamaan kaikki
// globaalit muuttujat ja viitteet
public class Ui_Handler : MonoBehaviour 
{
   
    // tarvitaan mineria varten:
    public NMBlockChain chain;
    public NMNode playerNode; // players wallet
    public NMPool pool; //transactions are here before mining
    public NMMiner miner ; //  mineri instanssi.

    bool dump_miner;

    public ulong prev_hash_miner; // this is stupid. its here cause we want to have it after miner is dumped

    void Start()
    {
        this.chain = new NMBlockChain();
        this.playerNode = new NMNode(1); // osoite 1
        this.pool = new NMPool();
        // ^^ nämä pysyy samana koko pelin ajan.

        this.dump_miner = true; // true here, this causes creation of intial miner
        
        
    }
    void Update()
    {
        //print(chain.getTop().hashThisBlock);
    }


    //   methods that we can call from elements in ui
    public void OnMinerClick(){
        ulong[] mine_ret;

        if (this.dump_miner){
            miner = new NMMiner(chain,playerNode,pool);
            dump_miner = false;
        }
        try{
            mine_ret = miner.Mine();
            this.prev_hash_miner= mine_ret[0];
            if (mine_ret[1]== 1){ 
                //Debug.Log("block was found!");
                dump_miner = true;
            }
        }catch (System.Exception){
            this.dump_miner = true;
            //Debug.Log("Trying to mine old block");
        }


    }

    public void OnTransClick(int id){
        Debug.Log(" klikattiin trasaktiota: "+ id);
        Transaction trans = pool.getTransaction(id);
        miner.toBeBlock.AddTrans(trans);
    }
}
