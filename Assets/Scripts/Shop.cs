using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //Item initiators //TODO game balancing with prices and increments
    //is this really the way to do it lol
    static Item item_1 = new Item(0, "Pickaxe",         1, 1.5, 1); //clickinc, not autoinc
    static Item item_2 = new Item(1, "Fan",             200, 2, 2);
    static Item item_3 = new Item(2, "Mead",            1000, 10, 3);
    static Item item_4 = new Item(3, "Waifu",           10000, 25, 4);
    static Item item_5 = new Item(4, "Hat",             50000, 50, 5);
    static Item item_6 = new Item(5, "Canary",          100000, 100, 10);
    static Item item_7 = new Item(6, "Glasses",         250000, 500, 25);
    static Item item_8 = new Item(7, "Shoulders",       0, 0, 0); //TODO
    static Item item_9 = new Item(8, "Bank",            500000, 1000, 200);
    static Item item_10 = new Item(9, "Drill",          1000000,2000, 500);
    static Item item_11 = new Item(10, "Robot Arm",     50000000, 5000, 1000);
    static Item item_12 = new Item(11, "Stocks",        100000000, 10000, 5000);
    static Item item_13 = new Item(12, "Sacrifice",     250000000, 20000, 250000);
    static Item item_14 = new Item(13, "Alchemy",       500000000, 50000, 500000);
    static Item item_15 = new Item(14, "Plasma Ray",    750000000, 75000, 750000);
    static Item item_16 = new Item(15, "Ascended",      1000000000, 1000000, 1000000);
    static Item item_17 = new Item(16, "Mine God",      0, 0, 0); //TOOD
    static Item[] items = new Item[17] { item_1, item_2, item_3, item_4, item_5, item_6, item_7, item_8, item_9, item_10, item_11, item_12, item_13, item_14, item_15, item_16, item_17 };

    // GETTERS AND SETTERS
    public static void purchase(int i)
    {
        items[i].purchase();

        FindObjectOfType<AudioManager>().Play("shopPurchase");
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
