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
    static int autoIncrement = 0; //referred to simply as "increment" everywhere else, may be confused with per click increment
    //TODO inventory array for quantity of items, 3 pickaxes, 1 poato etc. 

    static double AFKMultiplier = 0.2;

    //manual clicking
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
        //get time diff
        DateTime lastSave = Save.getLastSave();
        DateTime currentTime = DateTime.Now;
        TimeSpan diff = currentTime.Subtract(lastSave);
        double diffSeconds = diff.TotalSeconds;

        //calculate reward
        double gReward = (diffSeconds * getIncrement() * getAFKMultiplier());

        //reward gold
        addGold((int)gReward);
        Debug.Log("Player rewarded " + (int)gReward + "gold!");
        }

    // Start is called before the first frame update
    void Start()
    {
        Save newGame = new Save();
        newGame.LoadGame();
        afkReward();
        InvokeRepeating("autoClick", 1f, 1f); //call autoclick every second
        InvokeRepeating("newGame.SaveGame()", 60f, 60f); // auto-save game every 60 seconds
    }

    // Update is called once per frame
    void Update()
    {
        //UI displays. move to other script file eventually(?)
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

    public static void setIncrement(int i)
    {
        autoIncrement = i;
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

    public static void setGold(int i)
    {
        gold = i;
    }

    //afk
    private static double getAFKMultiplier()
    {
        double m = AFKMultiplier;
        return m;
    }

}
