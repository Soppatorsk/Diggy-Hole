using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goldPopUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Text>().text = "+" + Main.getClickInc().ToString();
        Object.Destroy(gameObject, 1f);

    }
}
