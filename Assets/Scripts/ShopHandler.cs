using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHandler : MonoBehaviour
{
    public GameObject shopTab1;
    public GameObject shopTab2;
    public GameObject shopTab3;
    public GameObject shopTab4;

    private void Start()
    {
        shopTab1.SetActive(true);
        shopTab2.SetActive(false);
        shopTab3.SetActive(false);
        shopTab4.SetActive(false);
    }

    public void gotoShopTab(int i)
    {
        shopTab1.SetActive(false);
        shopTab2.SetActive(false);
        shopTab3.SetActive(false);
        shopTab4.SetActive(false);

        switch (i)
        {
            case 1:
                shopTab1.SetActive(true);
                break;
            case 2:
                shopTab2.SetActive(true);
                break;
            case 3:
                shopTab3.SetActive(true);
                break;
            case 4:
                shopTab4.SetActive(true);
                break;
            default:
                shopTab1.SetActive(true);
                break;
        }
    }
}
