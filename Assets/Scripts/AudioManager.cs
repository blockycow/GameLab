using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    // Start is called before the first frame update
    void Awake()
    {
        GetInstance();
    }

    public void PlaySFX(AudioClip clip, Vector3 position)
    {
        GameObject soundObject = new GameObject("Sound");
        soundObject.transform.position = position;

        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.spatialBlend = 1f; 
        audioSource.Play();

        Destroy(soundObject, clip.length); 
    }
}
