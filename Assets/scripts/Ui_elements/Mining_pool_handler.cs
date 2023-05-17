using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// elää GameObjectissa jonka lapsiksi halutaan mainerit/upgraded tms. lisätä
public class Mining_pool_handler : MonoBehaviour
{

    public GameObject pool_miner_prefab;

    public GameObject main_handler;

    public void addNewPoolMember(string type, string desc, int hashRate){

            //TODO fiksummat lokaatiot tää on aivan persiistä.
            Vector2 pos_offset = Random.insideUnitCircle * 2;
            Vector3 pos = new Vector3(transform.position.x + pos_offset.x, transform.position.y+pos_offset.y, transform.position.z);

            
            GameObject asd = Instantiate(pool_miner_prefab ,pos, transform.rotation, transform);
            asd. GetComponent<Mining_agent>().InPLayersPool = true;
            asd.GetComponent<Mining_agent>().main_handler = main_handler;
            asd.GetComponent<Mining_agent>().type = type;
            asd.GetComponent<Mining_agent>().desc = desc;
            asd.GetComponent<Mining_agent>().frames_between_hashes = hashRate;
            asd.GetComponent<Mining_agent>().agentNode = main_handler.GetComponent<Ui_Handler>().playerNode;
    }

}
