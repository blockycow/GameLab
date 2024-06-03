using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

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

    public void ReadFile()
    {
        // Does the file exist?
        if (File.Exists(saveFile))
        {
            // Read the entire file and save its contents.
            string fileContents = File.ReadAllText(saveFile);

            // Deserialize the JSON data 
            //  into a pattern matching the GameData class.
            gameData = JsonUtility.FromJson<GameData>(fileContents);
        }
    }

    public void WriteFile()
    {
        // Work with JSON
        string jsonString = JsonUtility.ToJson(gameData);

        // Write JSON to file.
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