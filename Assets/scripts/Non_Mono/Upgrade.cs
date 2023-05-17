using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        int hashrate = 60/frames_between_hashes;
        return name + "\n"+ desc +" \n hashRate:" + hashrate + "hash/sec"+ "\n price: "+  price; 
    }
}
