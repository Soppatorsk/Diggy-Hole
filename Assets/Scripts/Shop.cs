using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Shop : MonoBehaviour
{
    //Item initiators //TODO game balancing with prices and increments
    static Item item_1 = new Item(0, "Pickaxe", 10, 1.1, 1);
    static Item item_2 = new Item(1, "Potato", 25, 1.1, 2);
    static Item item_3 = new Item(2, "Diamond Pickaxe", 1, 1, 999999999);
    static Item[] items = new Item[3] { item_1, item_2, item_3}; //for loop to auto generate array?


    // GETTERS AND SETTERS
    public static void purchase(int i)
    {
        items[i].purchase();
    }

    public static string getTitle(int i)
    {
        return items[i].getTitle();
    }

    public static long getPrice(int i)
    {
        return items[i].getPrice();
    }

    public static long getAutoInc(int i)
    {
        return items[i].getAutoInc();
    }
}
