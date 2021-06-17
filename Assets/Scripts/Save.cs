using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class Save : MonoBehaviour
{
    public DateTime lastSave;

    public static void WriteToFile<Player>(Player PlayerCopy, bool append = false)
    {
        using (Stream stream = File.Open(Application.persistentDataPath
                       + "/MyDwarf.dat", append ? FileMode.Append : FileMode.Create))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(stream, PlayerCopy);
        }
    }

    public static Player ReadFromFile<Player>()
    {
        using (Stream stream = File.Open(Application.persistentDataPath
                       + "/MyDwarf.dat", FileMode.Open))
        {
            var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            return (Player)binaryFormatter.Deserialize(stream);
        }
    }

    public static void SaveGame(Player playerdata)
    {
        WriteToFile(playerdata);
    }

    public static Player LoadGame()
    {
        return ReadFromFile<Player>();
    }

    public void ResetGame()
    {
        if (File.Exists(Application.persistentDataPath
                  + "/MyDwarf.dat"))
        {
            File.Delete(Application.persistentDataPath
                              + "/MyDwarf.dat");
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    public DateTime getLastSave()
    {
        DateTime d = lastSave;
        return d;
    }
}
