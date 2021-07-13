/*
     * !!! 
     * Changing this class will probably fuck up save files
     * If necessary, make sure to have compability/convert old save files 
     * It would suck if every player lost their save data just because we decided to fuck with this
     * !!!
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable()]
public class Player : ISerializable
{
    public double gold = 0;
    public double clickInc = 1;
    public double autoInc = 0;

    public int[] inventory = new int[5];

    public DateTime lastSave;

    public Player() { }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("gold", gold, typeof(double));
        info.AddValue("clickInc", clickInc, typeof(double));
        info.AddValue("autoInc", autoInc, typeof(double));
        info.AddValue("inventory", inventory, typeof(int[]));
        info.AddValue("last save", lastSave, typeof(DateTime));
    }

    public Player(SerializationInfo info, StreamingContext context)
    {
        gold = (double)info.GetValue("gold", typeof(double));
        clickInc = (double)info.GetValue("clickInc", typeof(double));
        autoInc = (double)info.GetValue("autoInc", typeof(double));
        inventory = (int[])info.GetValue("inventory", typeof(int[]));
        lastSave = (DateTime)info.GetValue("last save", typeof(DateTime));
    }
}
