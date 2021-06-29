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
        priceDisplay.GetComponent<Text>().text = "€" + Shop.getPrice(id).ToString();
        autoIncDisplay.GetComponent<Text>().text = "+" + Shop.getAutoInc(id).ToString() + " gps";
        rankDisplay.GetComponent<Text>().text = "Rank " + Main.getInventory(id);
    }

    // Update is called once per frame
    void Update()
    {
        priceDisplay.GetComponent<Text>().text = "€" + Shop.getPrice(id).ToString(); // only need to call per purchase. but shit dont work so lol
    }
}
