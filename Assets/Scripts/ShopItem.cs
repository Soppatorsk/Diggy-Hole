using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public GameObject titleDisplay;
    public GameObject priceDisplay;
    public GameObject autoIncDisplay;
    public GameObject rankDisplay;

    public Button purchaseItemBtn;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        titleDisplay.GetComponent<Text>().text = Shop.getTitle(id).ToString();
        priceDisplay.GetComponent<Text>().text = Main.numberFormatter(Shop.getPrice(id));
        autoIncDisplay.GetComponent<Text>().text = "+" + Main.numberFormatter(Shop.getAutoInc(id));
    }

    // Update is called once per frame
    void Update()
    {
        priceDisplay.GetComponent<Text>().text = Main.numberFormatter(Shop.getPrice(id)) + "g"; //TODO only need to call per purchase. but shit dont work so lol
        rankDisplay.GetComponent<Text>().text = "LV: " + Main.getInventory(id);
        ButtonToggle();
    }

    void ButtonToggle()
    {
        if (Main.getGold() >= Shop.getPrice(id))
        {
            purchaseItemBtn.interactable = true;
            priceDisplay.GetComponent<Text>().color = Color.black;
        } else
        {
            purchaseItemBtn.interactable = false;
            priceDisplay.GetComponent<Text>().color = Color.red;
        }
    }
}
