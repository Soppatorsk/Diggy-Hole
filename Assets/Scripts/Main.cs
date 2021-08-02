using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Main : MonoBehaviour
{
    //TODO save/load game fix
    public GameObject goldDisplay;
    public GameObject autoIncDisplay;

    public GameObject comboDisplay;
    public GameObject comboBar;
    public GameObject comboBox;

    static Player Player1 = new Player();

    Rock newRock = new Rock(1, 0);

    int goldCountSpeed = 100; //pointless over 60 because of refresh rate?
    double AFKMultiplier = 0.2;

    int comboMultiplier = 1; //TODO maybe combo in its own class
    int comboCounter = 0;
    int comboCounterLimit = 50;
    int combo2xCutoff = 10;
    int combo3xCutoff = 40;

    public GameObject bonusObjClick;

    public static float bonusClickInc = 1;

    void Start()
    {
        loadGame();
        afkReward();
        newRock = RockHandler();
        InvokeRepeating("autoClick", .01f, .01f);
        InvokeRepeating("comboTick", .5f, .5f);
        InvokeRepeating("saveGame", 60f, 60f);
    }

    void Update()
    {
        //UI displays, make a UI Handler?
        goldDisplay.GetComponent<Text>().text = String.Format("{0:0000000000000000000}", getGold());
        autoIncDisplay.GetComponent<Text>().text = "Gold/s " + numberFormatter(getAutoInc());

        comboDisplay.GetComponent<Text>().text = "x" + getComboMultiplier().ToString();
        comboBar.transform.position = new Vector3(comboCounter * 5 - 100, 1200, 0);
        
        //Debug.Log(comboCounter + "," + comboMultiplier);
    }

    public void afkReward()
    {
        
        TimeSpan diff = DateTime.Now.Subtract(getSaveDate());

        double diffSeconds = diff.TotalSeconds;
        Debug.Log(diffSeconds);
        double gReward = (diffSeconds * getAutoInc() * getAFKMultiplier());
        //reward gold
        addGold(gReward);

        Debug.Log("Player rewarded " + gReward + " gold!");
    }

    public Rock RockHandler() //static?
    {
        //generate rock based on gold etc
        System.Random rnd = new System.Random();
        int i = rnd.Next(4);
        switch (i)
        {
            case 0:
                return new Rock(5, 5);
            case 1:
                return new Rock(10, 10);
            case 2:
                return new Rock(25, 50);
            case 3:
                return new Rock(50, 100);
            default:
                return new Rock(1, 0);
        }
    }

    public void comboTick()
    {
        if (comboCounter > 0)
        {
            comboCounter--;
            getComboMultiplier();
        }
    }

    //manual clicking
    public void manualClick()
    {
        FindObjectOfType<AudioManager>().Play("rockHit");
        //addGold(Player1.clickInc * getComboMultiplier
        addGold(Player1.clickInc * bonusClickInc);
        int g = newRock.hit((int)Player1.clickInc * getComboMultiplier() * (int)bonusClickInc);
        if (g > 0)
        {
            Debug.Log("ROCK BREAK " + g + " gold ");
            FindObjectOfType<AudioManager>().Play("rockBreak");
            addGold(g);
            newRock = RockHandler();
        } else
        {
            //Debug.Log(newRock.getHP());
        }

        if (comboCounter < comboCounterLimit) { comboCounter++; }
    }

    //auto clicking
    void autoClick()
    {
        addGold(Player1.autoInc / goldCountSpeed); 
    }

    //Bonuses
    public void BonusClickInc()
    {
        Instantiate(bonusObjClick, new Vector3(0, 0), Quaternion.identity);
    }

    // GETTERS AND SETTERS
    //afk
    private double getAFKMultiplier()
    {
        return AFKMultiplier;
    }

    //save/load
    public void saveGame()
    {
        setSaveDate(DateTime.Now);
        Save.SaveGame(Player1);
        Debug.Log("Save the game");
    }

    public void loadGame()
    {
        Player1 = Save.LoadGame();
        Debug.Log("Loaded the game");
        //TODO update displays
    }

    public void resetGame()
    {
        Player1 = new Player();
    }

    //Combo
    public int getComboMultiplier()
    {
        int x = 1;
        if (comboCounter >= combo2xCutoff)
        {
            x = 2;
            if (comboCounter >= combo3xCutoff)
            {
                x = 3;
            }
        }
        comboMultiplier = x;
        return comboMultiplier;
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
            //Debug.Log("Not enough gold");
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

    //Save date
    public DateTime getSaveDate()
    {
        return Player1.saveDate;
    }

    public void setSaveDate(DateTime current)
    {
        Player1.saveDate = current;
    }

    public static string numberFormatter(double n)
    { //TODO replace E+04 etc with letters, d, c, k, m etc
        if (n >= 10000)
        {
           return n.ToString("G2", CultureInfo.InvariantCulture);
        } else
        {
            return n.ToString();
        }
    }
}
