using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// agentti, joita noi olla n+1 kun agentnode osoittaa pelaajaan toimii
// mining poolin jäsenenä/eli siis upgradena tms -> katso buy_one_upgrade
public class Mining_agent : MonoBehaviour
{

    public GameObject main_handler;


    NMBlockChain chain;
    public NMNode agentNode; //agents wallet // if we have this as player node this could work as cpu/mining pool member??
    NMPool pool; 
    NMMiner miner;
    GameObject ui_pool;
    public int  frames_between_hashes= 120;
    int id;
    public GameObject hashPrefab;

    // sörkitään nätä skriptissä joka luo  yksittäisen minerin.
    public bool InPLayersPool = false;
    public string type;
    public string desc;

    bool blockFoundLast = true;
    int rnd_off;

    void Start()
    {
        rnd_off = Random.Range(0,60);

        // what is the execution order?, did we set variables before this this point?..>
        if (!InPLayersPool){
            this.agentNode = new NMNode(this.id = Random.Range(0,int.MaxValue));
        }
        else{
            this.agentNode = main_handler.GetComponent<Ui_Handler>().playerNode;
        }

    }

    void Update()
    {
        this.chain = main_handler.GetComponent<Ui_Handler>().chain;
        this.pool = main_handler.GetComponent<Ui_Handler>().pool;
        this.ui_pool = main_handler.GetComponent<Ui_Handler>().ui_pool;


        ulong[] mine_ret  = new ulong[2];
        if (blockFoundLast){
             this.blockFoundLast = false;
            this.miner = new NMMiner(chain,agentNode,pool);
            miner.toBeBlock.AddListOfTrans(pool.transactionsInPool); // just add all that exist in this moment.
        }
        if((Time.frameCount+rnd_off) % frames_between_hashes == 1){

            try{
                mine_ret = miner.Mine();
                if (InPLayersPool){
                    SpawnText(mine_ret[0]);
                }
                if (mine_ret[1]== 1){ 
                    this.blockFoundLast = true;
                    ui_pool.GetComponent<Ui_Pool>().fieldClear();
                    // Debug.Log("mined for "+ agentNode.address);
                }
            }catch (System.Exception){
                this.blockFoundLast = true;
                ui_pool.GetComponent<Ui_Pool>().fieldClear();
                //Debug.Log("Trying to mine old block");
            }   
        }       
    }
    private void SpawnText(ulong hash) {

        float spawnOffsetRange = 3f;
        float spawnOffsetRangeX = 30f;

        // Instantiate a new text object from the prefab with random offset
        float randomOffsetX = Random.Range(-spawnOffsetRangeX, spawnOffsetRangeX);
        float randomOffsetY = Random.Range(-spawnOffsetRange, spawnOffsetRange);
        Vector2 spawnOffset = new Vector2(transform.position.x+ randomOffsetX, transform.position.y+randomOffsetY-300f);

        GameObject newText = Instantiate(hashPrefab, GameObject.FindObjectOfType<Canvas>().transform);
        newText.GetComponent<Text>().text= hash.ToString();
        newText.SetActive(true);


        RectTransform rectTransform = newText.GetComponent<RectTransform>();
        rectTransform.anchoredPosition += spawnOffset;

        // Start the fade-out coroutine
        StartCoroutine(FadeOutTextasd(newText));
    }

    private System.Collections.IEnumerator FadeOutTextasd(GameObject textObject)
    {
        float moveSpeed = 20f;
        float fadeSpeed = 0.1f;
        RectTransform rectTransform = textObject.GetComponent<RectTransform>();
        CanvasRenderer canvasRenderer = textObject.GetComponent<CanvasRenderer>();

        while (canvasRenderer.GetAlpha() > 0f)
        {
            // Move hash up
            Vector2 newPosition = rectTransform.anchoredPosition + new Vector2(0f, moveSpeed) * Time.deltaTime;
            rectTransform.anchoredPosition = newPosition;

            // Change alpha from 1 to 0
            float newAlpha = canvasRenderer.GetAlpha() - fadeSpeed * Time.deltaTime;
            newAlpha = Mathf.Clamp01(newAlpha);
            canvasRenderer.SetAlpha(newAlpha);

            yield return null;
        }

        // Destroy the text object when it has completely faded out
        Destroy(textObject);
    }

}
