using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The data of every player in the leaderboard list
// -Frieda
[Serializable]
public class PlayerData
{
    public string PlayerName;
    public float PlayerTime;

    // The data for when there's nothing yet.
    public PlayerData()
    {
        PlayerName = "-";
        PlayerTime = 0f;
    }

    // Set the data to the saved data.
    public PlayerData(string _name, float _time)
    {
        PlayerName = _name;
        PlayerTime = _time;
    }
}
