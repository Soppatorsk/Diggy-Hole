using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    public int gold = Main.getGold();
    public int increment = Main.getIncrement();
    //item array
    public string time = System.DateTime.Now.ToLongDateString();


    void SaveGame()
    {
        PlayerPrefs.SetInt("Player total gold", gold);
        PlayerPrefs.SetInt("Player gold per second", increment);
        //# of each item, item array

        PlayerPrefs.SetString("Save Date", time);

        //options

        PlayerPrefs.Save();

    }

    void LoadGame()
    {
        if (PlayerPrefs.HasKey("Save Date"))
        {
            //todo, implement saving first
        } else
        {
            //error
        }
    }

    void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
}
