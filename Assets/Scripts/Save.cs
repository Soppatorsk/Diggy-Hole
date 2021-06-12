using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public static DateTime lastSave;

    [Serializable]
    class SaveData
    {
        public int gold;
        public int autoInc;
        public int[] inventory;
        public DateTime saveDate;
    }

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/MySaveData.dat");
        SaveData data = new SaveData();
        //
        data.gold = Main.getGold();
        data.autoInc = Main.getAutoInc();
        data.saveDate = DateTime.Now;
        data.inventory = Main.getFullInventory(); //needs test
        lastSave = data.saveDate; //unneccesary?

        //
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            //
            Main.setGold(data.gold);
            Main.setAutoInc(data.autoInc);
            Main.setFullInventory(data.inventory); //needs test
            lastSave = data.saveDate; 
            //
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void ResetGame()
    {
        if (File.Exists(Application.persistentDataPath
                  + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
                              + "/MySaveData.dat");
            Main.setGold(0);
            Main.setAutoInc(0);
            Main.setFullInventory(null); //needs test
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    public static DateTime getLastSave()
    {
        DateTime d = lastSave;
        return d;
    }
}
