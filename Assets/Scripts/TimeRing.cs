using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


// The ring reduces the time for the player's score when they fly through it.
// -Elif
public class TimeRing : MonoBehaviour
{
    // The amount of seconds that is added to the start time to reduce the total time score.
    [SerializeField] private float addTimeAmount;
    [SerializeField] private AudioClip clip;

    private bool activated = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !activated)
        {
            TimeManager.Instance.startTime += addTimeAmount;
            TimeManager.Instance.StartTimeChanged();
            AudioManager.Instance.PlaySFX(clip,transform.position);
            activated = true;
        }
    }
}
