using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    //displays
    public GameObject shopTitle1;

    //Item initiators
    Item item_1 = new Item(1, "Pickaxe", 1, 1);

    //shop buttons (do I really need one for each button?)
    public void shopPurchase_1()
    {
        item_1.purchase();
    }

    // Start is called before the first frame update
    void Start()
    {
        shopTitle1.GetComponent<Text>().text = item_1.title;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
