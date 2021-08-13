using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;

public class Main : MonoBehaviour
{
    //TODO save/load game fix
    static Player Player1 = new Player();

    Rock newRock = new Rock(1, 0);

    int goldCountSpeed = 100; //pointless over 60 because of refresh rate?
    double AFKMultiplier = 0.2;

    int comboMultiplier = 1; //TODO maybe combo in its own class
    int comboCounter = 0;
    int comboCounterLimit = 50;
    int combo2xCutoff = 10;
    int combo3xCutoff = 40;

    public static float bonusClickInc = 1;

    void Start()
    {
        loadGame();
        afkReward();
        newRock = RockHandler();
        InvokeRepeating("autoClick", .01f, .01f);
        InvokeRepeating("comboTick", .5f, .5f);
        InvokeRepeating("saveGame", 60f, 60f);
        InvokeRepeating("rareSpawnHandler", 1f, 1f);
    }

    void Update()
    {
        //UI displays, make a UI Handler?
        ObjectManager.Get().goldDisplay.GetComponent<Text>().text = String.Format("{0:0000000000000000000}", getGold());
        ObjectManager.Get().autoIncDisplay.GetComponent<Text>().text = "Gold/s " + numberFormatter(getAutoInc());

        ObjectManager.Get().comboDisplay.GetComponent<Text>().text = "x" + getComboMultiplier().ToString();
        ObjectManager.Get().comboBar.transform.position = new Vector3(comboCounter * 5 - 100, 1200, 0);
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

    public Rock RockHandler()
    {
        //TODO generate rock based on gold etc
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

    //Bonuses
    public void rareSpawnHandler()
    {
        var rand = new System.Random();
        if (rand.Next(10) < 1)
        {
            Instantiate(ObjectManager.Get().rareSpawn, new Vector3(), Quaternion.identity, ObjectManager.Get().mainClick);
            Debug.Log("RARE SPAWN");
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

    // GETTERS AND SETTERS
    //afk
    private double getAFKMultiplier()
    {
        return AFKMultiplier;
    }

    //save/load
    public static void saveGame()
    {
        setSaveDate(DateTime.Now);
        Save.SaveGame(Player1);
        Debug.Log("Save the game");
    }

    public static void loadGame()
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

    public static void setSaveDate(DateTime current)
    {
        Player1.saveDate = current;
    }

    public static string numberFormatter(double n)
    { //TODO replace E+04 etc with letters, d, c, k, m etc
        string output = "";
        if (n >= 10000)
        {
            output = n.ToString("G2", CultureInfo.InvariantCulture);
            string eNum = output.Substring(Math.Max(0, output.Length - 4));
            switch (eNum) {
                case "E+04":
                    return output.Replace(eNum, "A");
                case "E+05":
                    return output.Replace(eNum, "B");
                case "E+06":
                    return output.Replace(eNum, "C");
                case "E+07":
                    return output.Replace(eNum, "D");
                case "E+08":
                    return output.Replace(eNum, "E");
                case "E+09":
                    return output.Replace(eNum, "F");
                case "E+10":
                    return output.Replace(eNum, "G");
                case "E+11":
                    return output.Replace(eNum, "H");
                case "E+12":
                    return output.Replace(eNum, "I");
                case "E+13":
                    return output.Replace(eNum, "J");
            }
        }

        return n.ToString();
    }
}
