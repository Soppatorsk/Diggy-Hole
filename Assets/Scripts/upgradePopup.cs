using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgradePopup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = Main.getLastBoughtUpgrade();
        Object.Destroy(gameObject, 1.5f);
    }
}
