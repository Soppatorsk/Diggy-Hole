using System;
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
    static int autoIncrement = 1; //testing, back to 0
    //inventory array for quantity of items, 3 pickaxes, 1 poato etc. 

    static double AFKMultiplier = 0.2;

    //clicking
    public void playerManualClick()
    {
        addGold(clickIncrement);
    }

    //auto clicking
    void autoClick()
    {
        addGold(autoIncrement);
    }

    public static void afkReward()
    {
        // get time of last save
        //System.DateTime lastSave = Save.getSaveDate();
        System.DateTime lastSave = new System.DateTime(2021, 06, 10); //test time, save/load game not yet implemented
        // get current 
        System.DateTime currentTime = System.DateTime.Now;
        // differnce in seconds
        System.TimeSpan diff = currentTime.Subtract(lastSave);
        double diffSeconds = diff.TotalSeconds;
        // calculate reward, apply multiplier
        double gReward = (diffSeconds * getIncrement() * getAFKMultiplier());
        // TODO display amount of reward to player
        addGold((int)gReward);
        }

    // Start is called before the first frame update
    void Start()
    {
        //TODO load game, if any
        //call autoclick every second
        afkReward();
        InvokeRepeating("autoClick", 1f, 1f);
        //InvokeRepeating, Save game every x seconds
    }

    // Update is called once per frame
    void Update()
    {
        //UI displays
        goldDisplay.GetComponent<Text>().text = "Gold " + getGold();
        incrementDisplay.GetComponent<Text>().text = "Increment " + getIncrement();
    }

    //GETTERS AND SETTERS

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

    //afk
    private static double getAFKMultiplier()
    {
        double m = AFKMultiplier;
        return m;
    }

}
