using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItem : MonoBehaviour
{
    public GameObject titleDisplay;
    public GameObject priceDisplay;
    public GameObject autoIncDisplay;
    public Button purchaseItemBtn;

    public int id;

    // Start is called before the first frame update
    void Start()
    {
        titleDisplay.GetComponent<Text>().text = Shop.getTitle(id).ToString();
        priceDisplay.GetComponent<Text>().text = "€" + Shop.getPrice(id).ToString();
        autoIncDisplay.GetComponent<Text>().text = "+" + Shop.getAutoInc(id).ToString() + " gps";
        Debug.Log(Shop.getPrice(id).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        priceDisplay.GetComponent<Text>().text = "€" + Shop.getPrice(id).ToString(); //performance hit?
    }
}
