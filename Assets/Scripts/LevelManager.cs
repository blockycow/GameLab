using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private PlayerControlSetting controlSetting;
    [SerializeField] private Transform spawnPoint;
    
    // Start is called before the first frame update
    void Awake()
    {
        var player = Instantiate(controlSetting.playerControls[controlSetting.playerControlIndex],
            spawnPoint.position, Quaternion.identity);
    }

    
}
