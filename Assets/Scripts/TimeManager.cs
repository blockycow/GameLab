using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// This keeps track of the time in the level.
// -Sandy
public class TimeManager : Singleton<TimeManager>
{
    public TMP_Text timerText;
    public float startTime;
    private bool isRunning = false;

    private float elapsedTime;
    
    // Start the timer when the level starts.
    void Awake()
    {
        GetInstance();
        StartTimer();
    }
    
    // Record the time when all the collectibles are or collected.
    void OnEnable() => CollectibleCount.CollectionCompleted += RecordTime;
    void OnDisable() => CollectibleCount.CollectionCompleted  -= RecordTime;

    void Update()
    {
        if (isRunning)
        {
            elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    // Start tracking the time.
    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    // Stop tracking
    public void StopTimer()
    {
        isRunning = false;
    }

    // Change the timer text to show the player time.
    private void UpdateTimerText(float elapsedTime)
    {
        if (timerText == null) return;
        
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        //int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Saves the time to the game data and saves the game data on the device.
    // Loads the titlescreen after saving.
    [Button]
    public void RecordTime()
    {
        StopTimer();
        elapsedTime = Time.time - startTime;
        startTime = Time.time;

        var playerScores = GameDataManager.Instance.gameData.PlayerScores;

        for (int i = 0; i < playerScores.Count; i++)
        {
            if (playerScores[i].PlayerTime >= elapsedTime || playerScores[i].PlayerTime == 0)
            {
                for (int j = playerScores.Count-1; j > i; j--)
                {
                    playerScores[j].PlayerName = playerScores[j-1].PlayerName;
                    playerScores[j].PlayerTime = playerScores[j-1].PlayerTime;
                }
                
                playerScores[i].PlayerName = GameDataManager.Instance.PlayerName;
                playerScores[i].PlayerTime = elapsedTime;
                
                GameDataManager.Instance.WriteFile();
                SceneManager.LoadScene(0);
                return;
            }
        }
    }
}
