using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //displays
    public GameObject debugText;

    //Item initiators
    public static Item item_1 = new Item(0, "Pickaxe", 1, 1);
    public static Item item_2 = new Item(1, "Potato", 2, 2);
    public static Item[] items = new Item[2] { item_1, item_2 };

    public void purchase(int itemID)
    {
        int i = itemID;
        int price = items[i].getPrice();
        int increment = items[i].getAutoInc();
        Main.removeGold(price);
        Main.addAutoInc(increment);
        Main.addInventory(i);
    }

    void Update()
    {
        debugText.GetComponent<Text>().text = "Item price: " + items[0].getPrice();
    }
}
