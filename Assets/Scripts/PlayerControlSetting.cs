using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

[CreateAssetMenu(menuName = "WoW/PlayerControlSetting", 
    fileName = "PlayerControlSetting",
    order = 0)]
public class PlayerControlSetting : ScriptableObject
{
    public int playerControlIndex = 0;
    public List<GameObject> playerControls;

    public void SetControlIndex(int idx)
    {
        playerControlIndex = idx;
    }
    
    public void SpawnPlayer()
    {
        Instantiate(playerControls[playerControlIndex], new Vector3(0,0,0), quaternion.identity);
    }
}
