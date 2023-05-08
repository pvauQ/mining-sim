using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Block block;
    public event System.Action onCookieClick;

    // Start is called before the first frame update
    void Start() {
        block = GetComponent<Block>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void buttonClicked() {
        if (onCookieClick != null) {
            onCookieClick();
        }
    }
}
