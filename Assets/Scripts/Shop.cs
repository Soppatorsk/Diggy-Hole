using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //Item initiators //TODO game balancing with prices and increments
    //is this really the way to do it lol
    static Item item_1 = new Item(0, "Pickaxe", "No more punching!", 1, 1.1, 1); //clickinc, not autoinc
    static Item item_2 = new Item(1, "Fan", "Keep cool!", 200, 1.2, 10);
    static Item item_3 = new Item(2, "Mead", "Alcohol!", 1000, 1.4, 20);
    static Item item_4 = new Item(3, "Waifu", "Comfort!", 10000, 1.6, 30);
    static Item item_5 = new Item(4, "Hat", "Warms your ears!", 50000, 1.8, 40);
    static Item item_6 = new Item(5, "Canary", "In a GOLD mine?", 100000, 2, 50);
    static Item item_7 = new Item(6, "Glasses", "Deal with it!", 250000, 2.1, 100);
    static Item item_8 = new Item(7, "Shoulders", "Shoulder pads!", 500000, 2.2, 200);
    static Item item_9 = new Item(8, "Bank", "Interest!", 750000, 2.3, 500);
    static Item item_10 = new Item(9, "Drill", "Technology!", 1000000, 2.4, 1000);
    static Item item_11 = new Item(10, "Robot Arm", "ROKKETO PAANCH!", 50000000, 2.5, 5000);
    static Item item_12 = new Item(11, "Stocks", "Stonks!", 100000000, 2.6, 10000);
    static Item item_13 = new Item(12, "Sacrifice", "Poor goat!", 250000000, 2.7, 250000);
    static Item item_14 = new Item(13, "Alchemy", "Make gold with your gold!", 500000000, 2.8, 500000);
    static Item item_15 = new Item(14, "Plasma Ray", "Ray go brrrr!", 750000000, 2.9, 750000);
    static Item item_16 = new Item(15, "Ascended", "BEYOND DWARF", 1000000000, 3, 1000000);
    static Item item_17 = new Item(16, "Mine God", "", 0, 0, 0); //TOOD
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
