using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// this scripts works only when it lives on the same GameObject as UI_Handler
// adds trans to pool,simple :3
public class Trans_agent : MonoBehaviour
{
    public int frames_between_trans;
    public int[] fee_range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Time.frameCount % frames_between_trans == 1){
            int fee = Random.Range(fee_range[0], fee_range[1]);
            int rnd_adr = Random.Range(0,int.MaxValue);
            Transaction trans  = new Transaction(fee,rnd_adr,666);
            bool added = GetComponent<Ui_Handler>().pool.addTransAction(trans);
            //Debug.Log(added);

            
        }
        
    }
}
