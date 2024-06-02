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
        PlayerName = "-";
        PlayerTime = 0f;
    }

    public PlayerData(string _name, float _time)
    {
        PlayerName = _name;
        PlayerTime = _time;
    }
}
