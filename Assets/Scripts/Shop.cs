using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //Item initiators //TODO game balancing with prices and increments
    //is this really the way to do it lol
    static Item item_1 = new Item(0, "Pickaxe",         1, 1, 1);
    static Item item_2 = new Item(1, "Fan",             2, 2, 2);
    static Item item_3 = new Item(2, "Mead",            3, 3, 3);
    static Item item_4 = new Item(3, "Body Pillow",     4, 4, 4);
    static Item item_5 = new Item(4, "Hat",             5, 5, 5);
    static Item item_6 = new Item(5, "Canary",          10, 10, 10);
    static Item item_7 = new Item(6, "Glasses",         25, 25, 25);
    static Item item_8 = new Item(7, "Shoulder Pads",   100, 100, 100);
    static Item item_9 = new Item(8, "Bank",            200, 200, 200);
    static Item item_10 = new Item(9, "Drill",          500, 500, 500);
    static Item item_11 = new Item(10, "Robot Arm",     1000, 1000, 1000);
    static Item item_12 = new Item(11, "Stocks",        5000, 5000, 5000);
    static Item item_13 = new Item(12, "Sacrifice",     10000, 10000, 10000);
    static Item item_14 = new Item(13, "Alchemy Book",  20000, 20000, 20000);
    static Item item_15 = new Item(14, "Plasma Ray",    50000, 50000, 50000);
    static Item item_16 = new Item(15, "Ascended",      100000, 100000, 100000);
    static Item item_17 = new Item(16, "Mine God",      10000000, 10000000, 999999999);
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
