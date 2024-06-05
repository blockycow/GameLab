using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;


// The manager for all of the game data.
// -Frieda
public class GameDataManager : Singleton<GameDataManager>
{
    string saveFile;

    public string PlayerName = "";
    public GameData gameData = new GameData();

    void Awake()
    {
        GetInstance();
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/gamedata.json";
        gameData = new GameData();
        
        ReadFile();
    }

    // get the file and deserialize its contents.
    public void ReadFile()
    {
        if (File.Exists(saveFile))
        {
            string fileContents = File.ReadAllText(saveFile);

            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
    }

    // Convert data to json and write it to the file.
    public void WriteFile()
    {
        string jsonString = JsonUtility.ToJson(gameData);

        File.WriteAllText(saveFile, jsonString);
    }

    [Button]
    public void TestSaving()
    {
        gameData = new GameData();
        gameData.PlayerScores[0] = new PlayerData("Richard", 9000f); 
        
        WriteFile();
        int i = 0;
        foreach (var player in gameData.PlayerScores)
        {
            i++;
            print($"{i}: {player.PlayerName} {player.PlayerTime}");
        }
    }
    
    [Button]
    public void TestLoading()
    {
        ReadFile();
        int i = 0;
        foreach (var player in gameData.PlayerScores)
        {
            i++;
            print($"{i}: {player.PlayerName} {player.PlayerTime}");
        }
    }
}