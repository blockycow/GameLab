using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameData
{
    public List<PlayerData> PlayerScores = new List<PlayerData>();

    public GameData()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerScores.Add(new PlayerData());
        }
    }
}
