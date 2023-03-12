using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using Unity.Android.Types;
using JetBrains.Annotations;

public class Main : MonoBehaviour
{
    static Player Player1 = new Player();

    
    static double goldClick; // getClickInc, one click + bonuses

    Rock newRock = new Rock(1, 0);

    Transform shopDefault;
    bool shopUp = true;

    int goldCountSpeed = 100; //TODO pointless over 60 because of refresh rate?
    double AFKMultiplier = 0.2;

    double goldBefore;
    double goldDiff;

    int comboMultiplier = 1; //TODO maybe combo in its own class
    int comboCounter = 0;
    int comboCounterLimit = 50;
    int combo2xCutoff = 10;
    int combo3xCutoff = 40;

    int[] dwarfLevel = new int[] { 0, 1, 10, 25, 50, 100, 1000, 10000, };

    public static float bonusClickInc = 1;
    public static float bonusAutoInc = 1;

    public static int activeBonusA = 0;
    public static int activeBonusC = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
        resetGame(); //testing
        saveGame();
        //loadGame();
        afkReward(); 
        ascended();
        newRock = RockHandler();
        InvokeRepeating("autoClick", .01f, .01f);
        InvokeRepeating("comboTick", .5f, .5f);
        InvokeRepeating("saveGame", 60f, 60f);
        InvokeRepeating("rareSpawnHandler", 10f, 10f);
        InvokeRepeating("calcIncome", 1f, 1f);
    }

    void Update()
    {
        //UI displays, make a UI Handler?
        ObjectManager.Get().goldDisplay.GetComponent<Text>().text = String.Format("{0:0000000000000000000}", getGold());
        ObjectManager.Get().autoIncDisplay.GetComponent<Text>().text = "GPS " + numberFormatter((int)goldDiff);

        ObjectManager.Get().comboDisplay.GetComponent<Text>().text = "x" + getComboMultiplier().ToString();
            }

    public void afkReward()
    {
        
        TimeSpan diff = DateTime.Now.Subtract(getSaveDate());
        double diffSeconds = diff.TotalSeconds;
        double gReward = (diffSeconds * getAutoInc() * getAFKMultiplier());
        //reward gold
        addGold(gReward);
        Debug.Log("Player rewarded " + gReward + " gold!");
    }

    public Rock RockHandler()
    {
        System.Random rnd = new System.Random();
        int level = (int)Player1.clickInc+1;
        int i = rnd.Next(4);
        switch (i)
        {
            case 0:
                return new Rock((level*5)+1, level*5-1);
            case 1:
                return new Rock((level*10)+1, level*10-1);
            case 2:
                return new Rock((level*25)+1, level*25-1);
            case 3:
                return new Rock((level*50)+1, level*50-1);
            default:
                return new Rock(1, 0);
        }
    }

    public void toggleShop()
    {
        var shop = ObjectManager.Get().shopWindow;
        int d = 900;
        if (shopUp) { shop.transform.position -= new Vector3(0, d); shopUp = false; }
        else { shop.transform.position += new Vector3(0, d); shopUp = true; }
    }


    public void comboTick()
    {
        if (comboCounter > 0)
        {
            comboCounter--;
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

    //income calc
    public void calcIncome()
    {
        double goldNow = getGold();
        if (goldNow - goldBefore >= 0 )
        {
            goldDiff = goldNow - goldBefore;
            goldBefore = goldNow;
        } else
        {
            goldDiff = goldBefore;
            goldBefore = goldNow;
        }
    }

    //manual clicking
    public void manualClick()
    {
        FindObjectOfType<AudioManager>().Play("rockHit");
        addGold(Player1.clickInc * bonusClickInc * getComboMultiplier());
        int g = newRock.hit((int)Player1.clickInc * getComboMultiplier() * (int)bonusClickInc);
        if (g > 0)
        {
            Debug.Log("ROCK BREAK " + g + " gold ");
            FindObjectOfType<AudioManager>().Play("rockBreak");
            addGold(g);
        Instantiate(ObjectManager.Get().goldChunk, new Vector3(ObjectManager.Get().goldChunkContainer.transform.position.x, ObjectManager.Get().goldChunkContainer.transform.position.y), Quaternion.identity, ObjectManager.Get().goldChunkContainer.transform);
            newRock = RockHandler();
        } 

        if (comboCounter < comboCounterLimit) { comboCounter++; }

        goldClick = Player1.clickInc * bonusClickInc * getComboMultiplier() + g;
        Instantiate(ObjectManager.Get().goldPopup, new Vector3(ObjectManager.Get().goldPopupContainer.transform.position.x, ObjectManager.Get().goldPopupContainer.transform.position.y), Quaternion.identity, ObjectManager.Get().goldPopupContainer.transform);
    }

    //auto clicking
    void autoClick()
    {
        addGold(Player1.autoInc * bonusAutoInc / goldCountSpeed);
    }

    // GETTERS AND SETTERS

    public static double getClickInc()
    {
        return goldClick;
    }

    public static void addAutoInc(double i)
    {
        Player1.autoInc += i;
    }

    //level
    public void getLevel()
    {
        double a = getAutoInc();
        foreach (int levelreq in dwarfLevel)
        {
            //
        }
    }
        
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
        Debug.Log("Saved the game");
    }

    public static void loadGame()
    {
        Player1 = Save.LoadGame();
        Debug.Log("Loaded the game");
    }

    public void resetGame()
    {
        Player1 = new Player();
    }

    //Combo
    public int getComboMultiplier()
    {
        int x = 1;
        Color y = new Color(193, 153, 60,1); //TODO custom color pls why
        ObjectManager.Get().comboBar.GetComponent<Image>().color = Color.white;
        if (comboCounter >= combo2xCutoff)
        {
            x = 2;
        Color o = new Color(193, 127, 60);
            ObjectManager.Get().comboBar.GetComponent<Image>().color = Color.yellow;
            if (comboCounter >= combo3xCutoff)
            {
                x = 3;
        Color r = new Color(231, 113, 53);

            ObjectManager.Get().comboBar.GetComponent<Image>().color = Color.red;
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

    public static void addClickInc(double i)
    {
        Player1.clickInc += i;
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

    public static void addGold(double i)
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

    //Inventory item quantity
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
    {
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

    public static void ascended()
    {
        if (getInventory(15) > 0)
        {
        ObjectManager.Get().Dwarf.GetComponent<Animator>().runtimeAnimatorController = null;
        ObjectManager.Get().Dwarf.GetComponent<Image>().sprite = ObjectManager.Get().AscDwarfSprite;
        ObjectManager.Get().Dwarf.GetComponent<Animator>().runtimeAnimatorController = ObjectManager.Get().AscDwarfAnim;
        }
    }
}
