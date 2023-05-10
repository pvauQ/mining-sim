using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Liitetään tämä peliobjeksi jota käytetään jemmaamaan kaikki
// globaalit muuttujat ja viitteet
public class Ui_Handler : MonoBehaviour 
{
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
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    // miten luetaan event napin klikkauksesta?
    // eventillä voidaan joka tapauksesse suorittaa yksi miner.mine() -> 0,1 tai exception.


}
