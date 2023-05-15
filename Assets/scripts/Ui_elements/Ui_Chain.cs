using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// elää GameObjetissa joka esittää lohkoketjua
public class Ui_Chain : MonoBehaviour
{
    public GameObject main_handler;
    public GameObject  Ui_block_prefab;
    public int prev_len; 
    float off_Set = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ui_block_prefab, transform.position, transform.rotation, transform);
        this.prev_len  =main_handler.GetComponent<Ui_Handler>().chain.blocks.Count;
    }

    // Update is called once per frame
    void Update()
    {
        int cur_len = main_handler.GetComponent<Ui_Handler>().chain.blocks.Count;
        if (prev_len < cur_len){
             Instantiate(Ui_block_prefab,new Vector3(transform.position.x + off_Set*cur_len, transform.position.y,transform.position.z), transform.rotation, transform);
            prev_len = cur_len;
        }
        
    }
}
