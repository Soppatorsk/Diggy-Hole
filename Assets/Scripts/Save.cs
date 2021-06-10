using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    int gold = Main.getGold();
    int increment = Main.getIncrement();
    //todo item array
    static System.DateTime saveDate = System.DateTime.Now;

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Player total gold", gold);
        PlayerPrefs.SetInt("Player gold per second", increment);
        //todo # of each item, item array
        //todo savedate
        //PlayerPrefs.SetString("Save Date", saveDate.ToString());
        //todo options
        PlayerPrefs.Save();
    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Save Date"))
        {
            //todo, implement saving first
        } else
        {
            //todo return error
        }
    }

    void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

    // GETTERS AND SETTERS
    public static System.DateTime getSaveDate()
    {
        System.DateTime r = saveDate;
        return r;
    }
}
