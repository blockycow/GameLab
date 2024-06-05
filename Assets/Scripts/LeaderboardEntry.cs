using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// The leaderboard entry object, that shows the time and name of the player
// -Sandy
public class LeaderboardEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text nameTmp;
    [SerializeField] private TMP_Text timeTmp;

    // Sets the time and name on the UI entry
    public void SetStats(string _name, float _time)
    {
        nameTmp.text = _name;
        
        int minutes = Mathf.FloorToInt(_time / 60F);
        int seconds = Mathf.FloorToInt(_time % 60F);
        int milliseconds = Mathf.FloorToInt((_time * 1000F) % 1000F);

        timeTmp.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    // Hides the text when there is no data.
    public void Hide()
    {
        nameTmp.text = "";
        timeTmp.text = "";
    }
}
