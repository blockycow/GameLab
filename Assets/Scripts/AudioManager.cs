using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void PlaySound(AudioClip clip, Vector3 position)
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


