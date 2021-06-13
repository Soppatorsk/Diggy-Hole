using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    int id;
    string title;
    //public string description;
    //icon img

    static int basePrice;
    static int price_K = 10;
    //TODO price increase with each purchase with some f(x) soemthing where x is getInventory(id)

    static int autoInc;

    //public int level; //TODO(?) upgrade level

    //constructor
    public Item(int itemID, string itemTitle, int itemBasePrice, int itemAutoInc)
    {
        id = itemID;
        title = itemTitle;
        basePrice = itemBasePrice;
        autoInc = itemAutoInc;
    }

    public int getPrice()
    {
        int price = price_K * Main.getInventory(id) + basePrice;
        return price;
    }

    public int getAutoInc()
    {
        int i = autoInc;
        return i;
    }
}
