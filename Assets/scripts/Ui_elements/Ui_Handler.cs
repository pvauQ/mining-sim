using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Liitetään tämä peliobjektiksi jota käytetään jemmaamaan kaikki
// globaalit muuttujat ja viitteet
public class Ui_Handler : MonoBehaviour 
{
    // eventti jotka passataan mainerille´
   
    public UnityEvent mine_click; 
    public UnityEvent<int> trans_click;

    // tarvitaan mineria varten:
    public NMBlockChain chain;
    public NMNode playerNode; // players wallet
    public NMPool pool; //transactions are here before mining
    public NMMiner miner ; //  mineri instanssi.


    // Start is called before the first frame update
    void Start()
    {
        this.chain = new NMBlockChain();
        this.playerNode = new NMNode(1); // osoite 1
        this.pool = new NMPool();
        // ^^ nämä pysyy samana koko pelin ajan.

        miner = new NMMiner(chain,playerNode,pool);
        // ^^ näitä luodaan uusia tarvittaessa.
        
        // luodaan kuuntelijoiden viittaukset
        if (mine_click == null)
            mine_click = new UnityEvent();
        mine_click.AddListener(OnMinerClick);
        if (trans_click == null)
            trans_click = new UnityEvent<int>();
        trans_click.AddListener(OnTransClick);
    }

    // Update is called once per frame
    void Update()
    {
        //print(chain.getTop().hashThisBlock);
    }

    public void OnMinerClick(){
        Debug.Log("klikattiin mainaus nappia");
        // mainaa bro
        // voidaan käyttää mineria ja kun se on valmis voidaan se dumpata
    }

    public void OnTransClick(int id){
        Debug.Log(" klikattiin trasaktiota: "+ id);
        Transaction trans = pool.getTransaction(id);
        miner.toBeBlock.AddTrans(trans);
    }
}
