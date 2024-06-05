using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// The ring reduces the time for the player's score when they fly through it.
// -Elif
public class TimeRing : MonoBehaviour
{
    // The amount of seconds that is added to the start time to reduce the total time score.
    [SerializeField] private float addTimeAmount;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TimeManager.Instance.startTime += addTimeAmount;
        }
    }
}
