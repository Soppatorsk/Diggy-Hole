using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopHandler : MonoBehaviour
{
    //TODO THIS IS A FUCKING MESS PLEASE REDO LOL

    public GameObject shopTab1;
    public GameObject shopTab2;
    public GameObject shopTab3;
    public GameObject shopTab4;

    public Button shopTabButton1;
    public Sprite shopTabButton1Off;
    public Sprite shopTabButton1On;

    public Button shopTabButton2;
    public Sprite shopTabButton2Off;
    public Sprite shopTabButton2On;

    public Button shopTabButton3;
    public Sprite shopTabButton3Off;
    public Sprite shopTabButton3On;

    public Button shopTabButton4;
    public Sprite shopTabButton4Off;
    public Sprite shopTabButton4On;

    private void Start()
    {
        gotoShopTab(1);
    }

    public void gotoShopTab(int i)
    {
        shopTab1.SetActive(false);
        shopTab2.SetActive(false);
        shopTab3.SetActive(false);
        shopTab4.SetActive(false);
        shopTabButton1.GetComponent<Image>().sprite = shopTabButton1Off;
        shopTabButton2.GetComponent<Image>().sprite = shopTabButton2Off;
        shopTabButton3.GetComponent<Image>().sprite = shopTabButton3Off;
        shopTabButton4.GetComponent<Image>().sprite = shopTabButton4Off;


        switch (i)
        {
            case 1:
                shopTab1.SetActive(true);
                shopTabButton1.GetComponent<Image>().sprite = shopTabButton1On;

                break;
            case 2:
                shopTab2.SetActive(true);
                shopTabButton2.GetComponent<Image>().sprite = shopTabButton2On;
                break;
            case 3:
                shopTab3.SetActive(true);
                shopTabButton3.GetComponent<Image>().sprite = shopTabButton3On;
                break;
            case 4:
                shopTab4.SetActive(true);
                shopTabButton4.GetComponent<Image>().sprite = shopTabButton4On;
                break;
            default:
                shopTab1.SetActive(true);
                shopTabButton1.GetComponent<Image>().sprite = shopTabButton1On;
                break;
        }
    }
}
