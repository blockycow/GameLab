using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{
    public List<LeaderboardEntry> entries;

    private void Start()
    {
        foreach (var entry in this.GetComponentsInChildren<LeaderboardEntry>())
        {
            entries.Add(entry);
        }
        SetLeaderboard();
    }

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

    [Button]
    public void ClearLeaderoard()
    {
        GameDataManager.Instance.gameData = new GameData();
        GameDataManager.Instance.WriteFile(); 
    }

    public void ChangeCurrentPlayerName(string _name)
    {
        GameDataManager.Instance.PlayerName = _name;
    }
}
