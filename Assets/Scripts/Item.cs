﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id;
    public string title = "item_Title";
    //public string description = "item_description";
    //icon img

    public int price = 1; 
    public int increment = 1;
    public int owned;
    //TODO price increase with each purchase with some f(x) soemthing where x is getInventory(id)

    //constructor
    public Item(int itemID, string itemTitle, int itemPrice, int itemIncrement)
    {
        id = itemID;
        title = itemTitle;
        price = itemPrice;
        increment = itemIncrement;
    }

    public void purchase()
    {
        if (Main.getGold() >= price)
        {
            Main.removeGold(price);
            Main.addAutoInc(increment);
            Main.addInventory(id);
        }
        else
        { /* do something */
            Debug.Log("Not enough gold");
        }
    }   
}
