using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public string PlayerName;
    public float PlayerTime;

    public PlayerData()
    {
        PlayerName = "Bob";
        PlayerTime = 99999999999f;
    }
}
