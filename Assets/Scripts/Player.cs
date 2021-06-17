using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[Serializable()]
public class Player : ISerializable
{
    public int gold = 0;
    public int clickInc = 1;
    public int autoInc = 0;

    public int[] inventory = new int[5];

    public Player() { }

    public void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        info.AddValue("gold", gold, typeof(int));
        info.AddValue("clickInc", clickInc, typeof(int));
        info.AddValue("autoInc", autoInc, typeof(int));
        info.AddValue("inventory", inventory, typeof(int[]));
    }

    public Player(SerializationInfo info, StreamingContext context)
    {
        gold = (int)info.GetValue("gold", typeof(int));
        clickInc = (int)info.GetValue("clickInc", typeof(int));
        autoInc = (int)info.GetValue("autoInc", typeof(int));
        inventory = (int[])info.GetValue("inventory", typeof(int[]));
    }
}
