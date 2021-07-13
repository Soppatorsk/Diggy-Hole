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
        autoIncDisplay.GetComponent<Text>().text = "+" + Shop.getAutoInc(id).ToString() + " gps";
        rankDisplay.GetComponent<Text>().text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        priceDisplay.GetComponent<Text>().text = Main.numberFormatter(Shop.getPrice(id)) + "g"; // only need to call per purchase. but shit dont work so lol
        rankDisplay.GetComponent<Text>().text = "Rank: " + Main.getInventory(id);
        ButtonToggle();
    }

    void ButtonToggle()
    {
        if (Main.getGold() >= Shop.getPrice(id))
        {
            purchaseItemBtn.gameObject.SetActive(true);
        } else
        {
            purchaseItemBtn.gameObject.SetActive(false);
        }
    }

}
