using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //displays
    public GameObject priceDisplay_1;

    //Item initiators
    static Item item_1 = new Item(0, "Pickaxe", 1, 1);
    static Item item_2 = new Item(1, "Potato", 25, 2);
    static Item item_3 = new Item(2, "Iron armor", 100, 3);
    static Item[] items = new Item[3] { item_1, item_2, item_3}; //for loop to auto generate array?

    public void purchase(int i)
    {
        items[i].purchase();
        priceDisplay_1.GetComponent<Text>().text = items[0].getPrice().ToString();
    }

    public void updateDisplays()
    {
        priceDisplay_1.GetComponent<Text>().text = items[0].getPrice().ToString();
    }

    void Start()
    {
        updateDisplays();
    }
}
