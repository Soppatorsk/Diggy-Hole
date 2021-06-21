using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //test
    public GameObject goldDisplay;
    public GameObject autoIncDisplay;

    static Player Player1 = new Player();

    int goldCountSpeed = 100; //pointless over 60 because of refresh rate?
    double AFKMultiplier = 0.2;

    void Start()
    {   
        //loadGameButton();
        //afkReward();
        InvokeRepeating("autoClick", .01f, .01f); //call autoclick every nth second, see goldCountSpeed
        //InvokeRepeating("Save.SaveGame()", 60f, 60f); // auto-save game every 60 seconds
    }

    void Update()
    {
        //UI displays. move to other script file eventually(?)
        goldDisplay.GetComponent<Text>().text = String.Format("{0:0000000000000000}", getGold());
        autoIncDisplay.GetComponent<Text>().text = "Gold/s " + getAutoInc(); //TODO handle int/double overflow
    }
    
    public void afkReward()
    {
        //get time diff
        DateTime lastSave = getLastSave();
        Debug.Log(getLastSave().ToString());
        DateTime currentTime = DateTime.Now;
        TimeSpan diff = currentTime.Subtract(lastSave);
        double diffSeconds = diff.TotalSeconds;
        //calculate reward
        double gReward = (diffSeconds * getAutoInc() * getAFKMultiplier());
        //reward gold
        addGold((int)gReward);
        Debug.Log("Player rewarded " + (int)gReward + " gold!");
    }
    
    //manual clicking
    public void manualClick()
    {
        addGold(Player1.clickInc);
    }

    //auto clicking
    void autoClick()
    {
        addGold(Player1.autoInc / goldCountSpeed); // 
    }

    // GETTERS AND SETTERS
    //afk
    private double getAFKMultiplier()
    {
        return AFKMultiplier;
    }

    public void saveGameButton()
    {
        Save.SaveGame(Player1);
        Debug.Log("Save the game");
    }

    public void loadGameButton()
    {
        Player1 = Save.LoadGame();
        Debug.Log("Loaded the game");
        //Shop.updateDisplays(); //TODO Fix this nullexception
    }

    //Automatic increment
    public static double getAutoInc()
    {
        return Player1.autoInc;
    }

    public static void addAutoInc(double i)
    {
        Player1.autoInc += i;
    }

    public void setAutoInc(double i)
    {
        Player1.autoInc = i;
    }

    //Gold
    public static double getGold()
    {
        return Player1.gold;
    }

    public void addGold(double i)
    {
        Player1.gold += i;
    }

    public static void removeGold(double i)
    {
        if (Player1.gold >= i)
        {
            Player1.gold -= i;
        }
        else
        {
            Debug.Log("Not enough gold");
        }

    }

    public void setGold(double i)
    {
        Player1.gold = i;
    }

    //Inventory item quantity //TODO a rename?
    public static int getInventory(int i)
    {
        return Player1.inventory[i];
    }

    public static void addInventory(int i)
    {
        Player1.inventory[i]++;
    }

    //Inventory
    public static int[] getFullInventory()
    {
        int[] i = new int[99];
        Player1.inventory = i;
        return i;
    }

    public void setFullInventory(int[] i)
    {
        Player1.inventory = i;
    }

    //Player, full stats. used in save file.

    internal static Player GetPlayer()
    {
        return Player1;
    }

    public static void setPlayer(Player clone)
    {
        Player1 = clone;
    }

    //Save date
    public DateTime getLastSave()
    {
        return Player1.lastSave;
    }
}
