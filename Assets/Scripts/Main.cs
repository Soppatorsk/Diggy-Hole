using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject goldDisplay;
    public GameObject autoIncDisplay;

    static int gold = 0;
    static int clickInc = 1;
    static int autoInc = 0;

    static int[] inventory = new int[99];
    /*NOTE: inventory currently has no direct link to player increment. 
    it is not calculated based on what items the player has.
    rather it is added on every shop purchase and then autoInc is saved directly as an int in the save file.
    thus no calculation. but it works as of now
    TODO make an updateStats() or something on game load, calculating increment by inventory
    TODO replace with the items[] array with a quantity parameter in it.
    */

    static double AFKMultiplier = 0.2;

    //manual clicking
    public void playerManualClick()
    {
        addGold(clickInc);
    }

    //auto clicking
    void autoClick()
    {
        addGold(autoInc);
    }

    public static void afkReward()
    {
        //get time diff
        DateTime lastSave = Save.getLastSave();
        DateTime currentTime = DateTime.Now;
        TimeSpan diff = currentTime.Subtract(lastSave);
        double diffSeconds = diff.TotalSeconds;
        //calculate reward
        double gReward = (diffSeconds * getAutoInc() * getAFKMultiplier());
        //reward gold
        addGold((int)gReward);
        Debug.Log("Player rewarded " + (int)gReward + " gold!");
        }

    void Start()
    {
        Save newGame = new Save();
        newGame.LoadGame();
        afkReward();
        InvokeRepeating("autoClick", 1f, 1f); //call autoclick every second
        //InvokeRepeating("newGame.SaveGame()", 60f, 60f); // auto-save game every 60 seconds
    }

    void Update()
    {
        //UI displays. move to other script file eventually(?)
        goldDisplay.GetComponent<Text>().text = "Gold " + getGold();
        autoIncDisplay.GetComponent<Text>().text = "Increment " + getAutoInc();
    }

    //GETTERS AND SETTERS
    //removed the return i; on getters, prob no difference but noting

    //Automatic increment
    public static int getAutoInc()
    {
        return autoInc;
    }

    public static void addAutoInc(int i)
    {
        autoInc += i;
    }

    public static void setAutoInc(int i)
    {
        autoInc = i;
    }

    //gold
    public static int getGold()
    {
        return gold;
    }

    public static void addGold(int i)
    {
        gold += i;
    }

    public static void removeGold(int i)
    {
        if (gold >= i)
        {
            gold -= i;
        } else
        {
            Debug.Log("Not enough gold");
        }
        
    }

    public static void setGold(int i)
    {
        gold = i;
    }

    //inventory, get specific item quantity
    public static int getInventory(int i)
    {
        return inventory[i];
    }

    public static void addInventory(int i)
    {
        inventory[i]++;
    }

    //entire inventory
    public static int[] getFullInventory()
    {
        int[] i = new int[99];
        inventory = i;
        return i;
    }

    public static void setFullInventory(int[] i)
    {
        inventory = i;
    }

    //afk
    private static double getAFKMultiplier()
    {
        return AFKMultiplier;
    }
    
}
