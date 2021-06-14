using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //displays
    public GameObject priceDisplay_1;

    //Item initiators
    public static Item item_1 = new Item(0, "Pickaxe", 1, 1);
    public static Item item_2 = new Item(1, "Potato", 25, 2);
    public static Item item_3 = new Item(2, "Iron armor", 100, 3);
    public static Item[] items = new Item[3] { item_1, item_2, item_3};


    public void purchase(int i)
    {
        items[i].purchase();
    }

    void Update()
    {
        priceDisplay_1.GetComponent<Text>().text = items[0].getPrice().ToString(); //TODO only update on purchase
    }
}
