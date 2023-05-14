using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buy_one_upgrade_remove_me : MonoBehaviour
{
    public GameObject ref_Mining_pool;
    void OnMouseDown(){
        
        ref_Mining_pool.GetComponent<Mining_pool_handler>().addNewPoolMember("apina", "karvainen apina", 680);
    }
}
