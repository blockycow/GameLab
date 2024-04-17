using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonSoundPlayer : MonoBehaviour
{
    [SerializeField] public AudioClip[] dragonSounds;
    public AudioSource audioSource;
    public int currentSoundIndex = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(CycleDragonSoundsRoutine());
    }

    IEnumerator CycleDragonSoundsRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20f, 40f)); 

            if (dragonSounds.Length > 0)
            {
                audioSource.clip = dragonSounds[currentSoundIndex];
                audioSource.Play();

                currentSoundIndex = (currentSoundIndex + 1) % dragonSounds.Length;
            }
        }
    }
}

