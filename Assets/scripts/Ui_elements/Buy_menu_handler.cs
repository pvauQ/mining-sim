using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Buy_menu_handler : MonoBehaviour
{  
    
    List<Upgrade> mainaajat;
    public GameObject main_handler;
    public GameObject buy_upgrade_prefab;
    public GameObject mining_pool; // here lives upgrades after


    void Start()
    {
        mainaajat = new List<Upgrade>();
        //  pitäiskö tämän tapahtua muualla, tarvitaanko tätä listaa missään muualla??? ei???
        mainaajat.Add(new Upgrade("Miner Monkey", "monkey bad at math mines coins for you",300, 200 ));
        mainaajat.Add(new Upgrade("Miner Gorilla", "Gorillas are good at math ", 110, 600 ));
        mainaajat.Add(new Upgrade("cs Student ", " CS student living in a dorm with free electricity ", 80, 800 ));
        mainaajat.Add(new Upgrade("Hacker monkey", "this monkey has access to AWS on his corporate account ", 30, 1200 ));
        mainaajat.Add(new Upgrade("coal powered mining farm", "this farm produces coins at fast speed with clean burning coal" , 7, 1_600 ));
        mainaajat.Add(new Upgrade("Norway", "you bribe all norvegians to use all of their electricity to mine coins" , 1, 12_000 ));       
    

    int y_poss_offset =  0 ;

    foreach(Upgrade miner in mainaajat){
        GameObject asd = Instantiate(buy_upgrade_prefab,new Vector3(transform.position.x, transform.position.y +  y_poss_offset,0), transform.rotation, transform);
        y_poss_offset -= 1;
        asd.transform.GetChild(0).GetComponent<TMP_Text>().text = miner.price.ToString()+ "Coins";
        asd.transform.GetChild(1).GetComponent<TMP_Text>().text = miner.ToString();
 
        // uusi maineri
        asd.GetComponent<Button>().onClick.AddListener(() => mining_pool.GetComponent<Mining_pool_handler>()
                                                            .addNewPoolMember(miner.name, miner.desc,miner.frames_between_hashes));

        // maksu

        asd.GetComponent<Button>().onClick.AddListener(() =>main_handler.GetComponent<Ui_Handler>().playerNode.sendFunds(miner.price,100));
    }   

    //TODO ei mennä miinukselle bro
    
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
