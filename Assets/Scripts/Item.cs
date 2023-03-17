using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    int id;
    string title;
    string popup;
 
    long basePrice;
    double price_K;

    long autoInc;

    // CONSTRUCTOR
    public Item(int itemID, string itemTitle, string itemPopup, long itemBasePrice, double itemPrice_k, long itemAutoInc)
    {
        id = itemID;
        title = itemTitle;
        popup = itemPopup;
        basePrice = itemBasePrice;
        price_K = itemPrice_k;
        autoInc = itemAutoInc;
    }

    public void purchase()
    {
        if (Main.getInventory(id) == 0)
        {
            Main.setLastBoughtUpgrade(popup);
            FindObjectOfType<AudioManager>().Play("wow");
            Instantiate(ObjectManager.Get().upgradePopup, new Vector3(ObjectManager.Get().upgradePopupContainer.transform.position.x, ObjectManager.Get().upgradePopupContainer.transform.position.y), Quaternion.identity, ObjectManager.Get().upgradePopupContainer.transform);
        }

        if (Main.getGold() >= getPrice())
        {
            Main.removeGold(getPrice());
            Main.addInventory(getItemID());
            //string msg = "Bought " + getTitle() + " for " + getPrice() + " gold, adding " + getAutoInc() + " gold per second >>>";
            //Debug.Log("You have " + Main.getInventory(getItemID()) + " " + getTitle());
            //Debug.Log(msg);
            if (this.id == 0)
            {
                Main.addClickInc(autoInc);
            }
            else Main.addAutoInc(getAutoInc());
        }
        else
        {
            Debug.Log("Not enough gold");
        }

        if (id == 15) Main.ascended();

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
        //where a = base price, b = k, x = rank
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
