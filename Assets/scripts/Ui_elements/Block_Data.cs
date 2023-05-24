using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block_Data : MonoBehaviour
{
    public int block_id;
    public GameObject tooltip_prefab;
    GameObject main_handler;
    GameObject tip;

    // Start is called before the first frame update
    void Start()
    {
        main_handler =GameObject.Find("Main_handler");
        
    }

    void OnMouseEnter(){
        if (tooltip_prefab != null){
            tip = Instantiate(tooltip_prefab, transform.position, Quaternion.identity,transform);
             tip.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            
             NMBlock block = main_handler.GetComponent<Ui_Handler>().chain.blocks[block_id];

            tip.GetComponent<TextMesh>().text = block.ToString();
         }
    }

    void OnMouseExit(){
        if(tip != null){
             Destroy(tip);
             tip = null;
        } 
    }
}
