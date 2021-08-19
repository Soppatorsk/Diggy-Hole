using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    int id;
    string title;
 
    long basePrice;
    double price_K;

    long autoInc;

    // CONSTRUCTOR
    public Item(int itemID, string itemTitle, long itemBasePrice, double itemPrice_k, long itemAutoInc)
    {
        id = itemID;
        title = itemTitle;
        basePrice = itemBasePrice;
        price_K = itemPrice_k;
        autoInc = itemAutoInc;
    }

    public void purchase()
    {
        if (Main.getGold() >= getPrice())
        {
            Main.removeGold(getPrice());
            Main.addAutoInc(getAutoInc());
            Main.addInventory(getItemID());
            //string msg = "Bought " + getTitle() + " for " + getPrice() + " gold, adding " + getAutoInc() + " gold per second >>>";
            //Debug.Log("You have " + Main.getInventory(getItemID()) + " " + getTitle());
            //Debug.Log(msg);

        }
        else
        {
            Debug.Log("Not enough gold");
        }
    }

    // GETTERS AND SETTERS
    private int getItemID()
    {
        return id;
    }

    public long getPrice()
    {
        return (long)(basePrice * Math.Pow(price_K, Main.getInventory(id)));
        //f(x)=ab^x
    }

    internal string getTitle()
    {
        return title;
    }

    public long getAutoInc()
    {
        return autoInc;
    }
}
