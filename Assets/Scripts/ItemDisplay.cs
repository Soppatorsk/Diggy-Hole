using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public int id;
    public Sprite[] sprites;
    int[] ranks = { 1, 2, 4, 7, 10 };

    private void Update()
    {
        var rank = Main.getInventory(id);
        if (rank >= 1)
        {
            gameObject.GetComponent<Image>().enabled = true;
        }

        //gameObject.GetComponent<Image>().sprite = sprites[2];
        
        for (int i = 0; i<5; i++)
        {
            if (rank >= ranks[i]) { gameObject.GetComponent<Image>().sprite = sprites[i]; }
        }

    }
}
