using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Upgrade
{
    public string name;
    public string desc;
    public int frames_between_hashes;
    public int price;

    public Upgrade(string name, string desc, int frames_between_hashes, int price){
        this.name= name;
        this.desc = desc;
        this.frames_between_hashes = frames_between_hashes;
        this.price = price;
    }

    public override string  ToString(){
        float hashrate = ((float)Math.Round(60f/frames_between_hashes, 2));
        return name + "\n"+ desc +" \n" + hashrate  + "hash/sec";
    }
}
