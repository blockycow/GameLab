using System;
using System.Collections;
using System.Collections.Generic;
using BNG;
using UnityEngine;

// Spawns in the player based on the choice made in the titlescreen.
// -Matthias
public class LevelManager : MonoBehaviour
{

    [SerializeField] private PlayerControlSetting controlSetting;
    [SerializeField] private Transform spawnPoint;
    
    void OnEnable() => CollectibleCount.CollectionCompleted += EndLevel;
    void OnDisable() => CollectibleCount.CollectionCompleted  -= EndLevel;
    
    // Start is called before the first frame update
    void Awake()
    {
        var player = Instantiate(controlSetting.playerControls[controlSetting.playerControlIndex],
            spawnPoint.position, spawnPoint.rotation);
        
    }

    private void Start()
    {
        TimeManager.Instance.StartTimer();
    }

    public void EndLevel()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        var lvlLoader = GetComponent<SceneLoader>();
        yield return new WaitForSeconds(1);
        lvlLoader.LoadScene("TitleScreen");
        
    }
}
