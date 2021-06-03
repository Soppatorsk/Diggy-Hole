using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject goldDisplay;
    public GameObject incrementDisplay;

    static int gold = 0;
    static int clickIncrement = 1;
    static int autoIncrement = 0;

    //clicking

    public void playerManualClick()
    {
        addGold(clickIncrement);
    }

    //auto increment
    public static int getIncrement()
    {
        int i = autoIncrement;
        return i;
    }

    public static void addIncrement(int i)
    {
        autoIncrement += i;
    }

    //gold
    public static int getGold()
    {
        int g = gold;
        return g;
    }

    public static void addGold(int i)
    {
        gold += i;
    }

    public static void removeGold(int i)
    {
        gold -= i;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //displays
        goldDisplay.GetComponent<Text>().text = "Gold " + getGold();
        incrementDisplay.GetComponent<Text>().text = "Increment " + getIncrement();

        //adds gold every frame. bad implementation! tie increment to actual seconds instead.
        //addGold(autoIncrement);
    }
}
