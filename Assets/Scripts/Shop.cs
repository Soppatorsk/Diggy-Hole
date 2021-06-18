using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //displays
    public static GameObject priceDisplay_1;

    //Item initiators //TODO game balancing with prices and increments
    static Item item_1 = new Item(0, "Pickaxe", 10, 1.1, 1);
    static Item item_2 = new Item(1, "Potato", 25, 1.1, 2);
    static Item item_3 = new Item(2, "Iron armor", 50, 1.1, 3);
    public static Item[] items = new Item[3] { item_1, item_2, item_3}; //for loop to auto generate array?

    public void purchase(int i)
    {
        items[i].purchase();
        priceDisplay_1.GetComponent<Text>().text = items[0].getPrice().ToString();
    }

    public static void updateDisplays()
    {
        priceDisplay_1.GetComponent<Text>().text = items[0].getPrice().ToString();

    }


    void Start()
    {
        updateDisplays();
    }
}
