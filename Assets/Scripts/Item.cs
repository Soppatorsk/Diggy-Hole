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

    int basePrice;
    int price_K = 10;
    //TODO price increase with each purchase with some f(x) soemthing where x is getInventory(id)

    int autoInc;

    //public int level; //TODO(?) upgrade level

    //constructor
    public Item(int itemID, string itemTitle, int itemBasePrice, int itemAutoInc)
    {
        id = itemID;
        title = itemTitle;
        basePrice = itemBasePrice;
        autoInc = itemAutoInc;
    }

    public void purchase()
    {
        if (Main.getGold() >= getPrice())
        {
            string msg = "Bought " + getTitle() + " for " + getPrice() + " gold, adding " + getAutoInc() + " gold per second >>>";
            Main.removeGold(getPrice());
            Main.addAutoInc(getAutoInc());
            Main.addInventory(getItemID()); //get?
            Debug.Log(msg);
        } else
        {
            Debug.Log("Not enough gold");
        }
    }

    //GETTERS AND SETTERS
    private int getItemID()
    {
        return id;
    }

    public int getPrice()
    {
        return price_K * Main.getInventory(id) + basePrice;
    }

    internal string getTitle()
    {
        return title;
    }

    public int getAutoInc()
    {
        return autoInc;
    }

   
}
