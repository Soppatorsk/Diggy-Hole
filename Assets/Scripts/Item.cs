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
    //Test comment

    int basePrice;
    double price_K;

    int autoInc;

    //public int level; //TODO(?) upgrade level

    // CONSTRUCTOR
    public Item(int itemID, string itemTitle, int itemBasePrice, double itemPrice_k, int itemAutoInc)
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
            string msg = "Bought " + getTitle() + " for " + getPrice() + " gold, adding " + getAutoInc() + " gold per second >>>";
            Main.removeGold(getPrice());
            Main.addAutoInc(getAutoInc());
            Main.addInventory(getItemID());
            Debug.Log("You have " + Main.getInventory(getItemID()) + " " + getTitle());
            Debug.Log(msg);

        } else
        {
            Debug.Log("Not enough gold");
        }
    }

    // GETTERS AND SETTERS
    private int getItemID()
    {
        return id;
    }

    public int getPrice()
    {
        return (int)(basePrice * Math.Pow(price_K, Main.getInventory(id)));
        //f(x)=ab^x
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
