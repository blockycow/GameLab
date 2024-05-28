using System.IO;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class GameDataManager : Singleton<GameDataManager>
{
    string saveFile;

    GameData gameData = new GameData();

    void Awake()
    {
        // Update the path once the persistent path exists.
        saveFile = Application.persistentDataPath + "/gamedata.json";
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
        GameData testData = new GameData();
        testData.PlayerScores = new List<PlayerData>();
        PlayerData player1 = new PlayerData();
        PlayerData player2 = new PlayerData();
        PlayerData player3 = new PlayerData();
        testData.PlayerScores.Add(player1);
        testData.PlayerScores.Add(player2);
        testData.PlayerScores.Add(player3);
        gameData = testData;
        WriteFile();
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