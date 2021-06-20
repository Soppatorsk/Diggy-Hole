using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    //test2
    public GameObject goldDisplay;
    public GameObject autoIncDisplay;
    public Shop newShop = new Shop();
    Save newGame = new Save();

    static Player Player1 = new Player();

    double AFKMultiplier = 0.2;

    void Start()
    {   
        //loadGameButton();
        afkReward();
        InvokeRepeating("autoClick", 1f, 1f); //call autoclick every second
        //InvokeRepeating("newGame.SaveGame()", 60f, 60f); // auto-save game every 60 seconds
    }

    void Update()
    {
        //UI displays. move to other script file eventually(?)
        goldDisplay.GetComponent<Text>().text = String.Format("{0:0000000000000000}", getGold());
        autoIncDisplay.GetComponent<Text>().text = "Gold per second " + getAutoInc();
    }

    
    public void afkReward()
    {
        //get time diff
        DateTime lastSave = newGame.getLastSave();
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
        addGold(Player1.autoInc);
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
        newShop.updateDisplays();
    }

    // GETTERS AND SETTERS

    //Automatic increment
    public static int getAutoInc()
    {
        return Player1.autoInc;
    }

    public static void addAutoInc(int i)
    {
        Player1.autoInc += i;
    }

    public void setAutoInc(int i)
    {
        Player1.autoInc = i;
    }

    //Gold
    public static int getGold()
    {
        return Player1.gold;
    }

    public void addGold(int i)
    {
        Player1.gold += i;
    }

    public static void removeGold(int i)
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

    public void setGold(int i)
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

}
