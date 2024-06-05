using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

// The leaderboard class that shows all of the entries.
// -Sandy
public class Leaderboard : MonoBehaviour
{
    public List<LeaderboardEntry> entries;

    //Get all of the entry objects and set their data
    private void Start()
    {
        foreach (var entry in this.GetComponentsInChildren<LeaderboardEntry>())
        {
            entries.Add(entry);
        }
        SetLeaderboard();
    }

    // Set the leaderboard data to the saved game data.
    [Button]
    public void SetLeaderboard()
    {
        var scores = GameDataManager.Instance.gameData.PlayerScores;
        for (int i = 0; i < entries.Count; i++)
        {
            if (i >= scores.Count)
            {
                entries[i].Hide();
                continue;
            }

            if (scores[i].PlayerName == "") scores[i].PlayerName = "No Name";
            entries[i].SetStats($"{i+1}. {scores[i].PlayerName}", scores[i].PlayerTime);
            entries[i].gameObject.SetActive(true);

            print($"{scores[i].PlayerName}: {scores[i].PlayerTime}");
        }
    }

    // Reset all of the leaderboard data for testing.
    [Button]
    public void ClearLeaderboard()
    {
        GameDataManager.Instance.gameData = new GameData();
        GameDataManager.Instance.WriteFile(); 
    }

    // Change the name of the player.
    public void ChangeCurrentPlayerName(string _name)
    {
        GameDataManager.Instance.PlayerName = _name;
    }
}
