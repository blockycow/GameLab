using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A manager for audio using Nemo's Singleton to have one Instance that plays the sound effects.
// -Bas
public class AudioManager : Singleton<AudioManager>
{

    [SerializeField] private float sfxVolume = 0.8f;
    void Awake()
    {
        GetInstance();
    }

    // This function plays an audio clip at a specific location.
    public void PlaySFX(AudioClip clip, Vector3 position)
    {
        GameObject soundObject = new GameObject("Sound");
        soundObject.transform.position = position;

        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.spatialBlend = 1f;
        audioSource.volume = sfxVolume;
        audioSource.Play();

        Destroy(soundObject, clip.length); 
    }
}
