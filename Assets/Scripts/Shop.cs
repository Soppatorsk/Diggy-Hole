using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //displays
    public GameObject titleDisplay_1;
    public GameObject priceDisplay_1;
    public GameObject autoIncDisplay_1;

    public GameObject titleDisplay_2;
    public GameObject priceDisplay_2;
    public GameObject autoIncDisplay_2;

    public GameObject titleDisplay_3;
    public GameObject priceDisplay_3;
    public GameObject autoIncDisplay_3;

    //Item initiators //TODO game balancing with prices and increments
    static Item item_1 = new Item(0, "Pickaxe", 10, 1.1, 1);
    static Item item_2 = new Item(1, "Potato", 25, 1.1, 2);
    static Item item_3 = new Item(2, "Diamond Pickaxe", 50, 1.1, 999999);
    static Item[] items = new Item[3] { item_1, item_2, item_3}; //for loop to auto generate array?

    public void purchase(int i)
    {
        items[i].purchase();
        updateDisplays();
    }

    public void updateDisplays() //TODO there has to be a way to iterate this. also, do I really need to make them an obejct each? very ugly.
    {
        priceDisplay_1.GetComponent<Text>().text = items[0].getPrice().ToString();
        priceDisplay_2.GetComponent<Text>().text = items[1].getPrice().ToString();
        priceDisplay_3.GetComponent<Text>().text = items[2].getPrice().ToString();

        autoIncDisplay_1.GetComponent<Text>().text = "+" + items[0].getAutoInc().ToString();
        autoIncDisplay_2.GetComponent<Text>().text = "+" + items[1].getAutoInc().ToString();
        autoIncDisplay_3.GetComponent<Text>().text = "+" + items[2].getAutoInc().ToString();
    }

    void initShop()
    {
        titleDisplay_1.GetComponent<Text>().text = items[0].getTitle();
        titleDisplay_2.GetComponent<Text>().text = items[1].getTitle();
        titleDisplay_3.GetComponent<Text>().text = items[2].getTitle();
        updateDisplays();
    }

    void Start()
    {
        initShop();   
    }
}
