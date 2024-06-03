using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : Singleton<TimeManager>
{

    public TMP_Text timerText; // UI Text component to display the timer
    private float startTime;
    private bool isRunning = false;

    void Start()
    {
        GetInstance();
        StartTimer();
    }
    
    void OnEnable() => CollectibleCount.CollectionCompleted += RecordTime;
    void OnDisable() => CollectibleCount.CollectionCompleted  -= RecordTime;

    void Update()
    {
        if (isRunning)
        {
            float elapsedTime = Time.time - startTime;
            UpdateTimerText(elapsedTime);
        }
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    private void UpdateTimerText(float elapsedTime)
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000f) % 1000f);

        timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }

    [Button]
    public void RecordTime()
    {
        StopTimer();
        float elapsedTime = Time.time - startTime;

        var playerScores = GameDataManager.Instance.gameData.PlayerScores;

        for (int i = 0; i < playerScores.Count; i++)
        {
            if (playerScores[i].PlayerTime >= elapsedTime || playerScores[i].PlayerTime == 0)
            {
                print("Saving at index: " + i);
                for (int j = playerScores.Count-1; j > i; j--)
                {
                    playerScores[j].PlayerName = playerScores[j-1].PlayerName;
                    playerScores[j].PlayerTime = playerScores[j-1].PlayerTime;
                    print(playerScores[j - 1].PlayerName);
                }
                
                playerScores[i].PlayerName = GameDataManager.Instance.PlayerName;
                playerScores[i].PlayerTime = elapsedTime;
                print("Saving: " + playerScores[i].PlayerName);
                
                GameDataManager.Instance.WriteFile();
                SceneManager.LoadScene(0);
                return;
            }
        }
        
        
    }
}
