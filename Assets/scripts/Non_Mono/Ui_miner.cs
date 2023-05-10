using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Liitetään tämä peliobjeksi jota käytetään jemmaamaan kaikki
// globaalit muuttujat ja viitteet
public class Ui_miner : MonoBehaviour 
{
    // tarvitaan mineria varten:
    public NMBlockChain chain;
    public NMNode player; // players wallet
    public NMPool pool; //transactions are here before mining
    public NMMiner miner ; //  mineri instanssi.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
