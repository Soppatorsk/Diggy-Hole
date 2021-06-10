using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public int id;
    public string title = "item_Title";
    //public string description = "item_description";
    //icon img

    public int price = 1; //price (and increment?) should increase per purchase exponentially. 
    public int increment = 1;
    public int quantity;

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
            Main.addIncrement(increment);
            quantity++;
        }
        else
        { /* do something */
        }
    }   
}
