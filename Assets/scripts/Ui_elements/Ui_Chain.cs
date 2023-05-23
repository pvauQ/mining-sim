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
    public  float speed = 1f;
    
    int blocks_on_screen;
    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ui_block_prefab, transform.position, transform.rotation, transform);
        this.prev_len  =main_handler.GetComponent<Ui_Handler>().chain.blocks.Count;
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // this is a shitty way to move blocks
        //TODO WE HAVE A LEAK, offscreen blocks are not destroyed
        if  (blocks_on_screen > 14){
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition){
                blocks_on_screen -=1;
            }
        }
    
        int cur_len = main_handler.GetComponent<Ui_Handler>().chain.blocks.Count;
        if (prev_len < cur_len){
            RandomColorInstantiate(cur_len);
            //  Instantiate(Ui_block_prefab,new Vector3(transform.position.x + off_Set*cur_len, transform.position.y,transform.position.z), transform.rotation, transform);
            prev_len = cur_len;

            // this is part of that
            blocks_on_screen +=1;
            if (blocks_on_screen > 14){
                targetPosition = new Vector3(targetPosition.x - 1,targetPosition.y,targetPosition.z);
                }
            }
    }

    void RandomColorInstantiate(int cur_len) {
        GameObject prefabInstance = Instantiate(Ui_block_prefab,new Vector3(transform.position.x + off_Set*cur_len, transform.position.y,transform.position.z), transform.rotation, transform);
        Renderer prefabRenderer = prefabInstance.GetComponent<Renderer>();
        if (prefabRenderer != null)
        {
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            prefabRenderer.material.color = randomColor;
        }
    }
}
