using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : MonoBehaviour, ICollidable
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AudioClip[] gnomeSounds;
    [SerializeField] private float[] soundStartTimes = { 0f, 1f, 2f, 3f, 4f, 5f };
    [SerializeField] private float torqueMagnitude = 5f;
    private AudioSource audioSource;

    private bool isWalking = false; 

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(PlayRandomSoundRoutine());
    }

    public void Collide(Collider collision, float force)
    {
        var forceSpread = force / 2.0f;
        rb.AddForce(new Vector3(
            Random.Range(-forceSpread, forceSpread),
            force,
            Random.Range(-forceSpread, forceSpread)), ForceMode.Impulse);

        Vector3 torque = Random.insideUnitSphere * torqueMagnitude;
        rb.AddTorque(torque, ForceMode.Impulse);
    }

    private IEnumerator PlayRandomSoundRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(10f, 30f));
            PlayRandomSound();
        }
    }

    private void PlayRandomSound()
    {
        if (gnomeSounds.Length > 0 && soundStartTimes.Length == gnomeSounds.Length)
        {
            int randomIndex = Random.Range(0, gnomeSounds.Length);
            audioSource.clip = gnomeSounds[randomIndex];
            float randomStartTime = soundStartTimes[randomIndex];
            audioSource.time = randomStartTime;
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0 && !isWalking)
        {
            PlayGnomeWalkingSound();
        }
        else if (rb.velocity.magnitude == 0 && isWalking)
        {
            StopGnomeWalkingSound();
        }
    }

    void PlayGnomeWalkingSound()
    {
        if (audioSource != null && gnomeSounds.Length > 0)
        {
            int randomIndex = Random.Range(0, gnomeSounds.Length);
            audioSource.clip = gnomeSounds[randomIndex];
            audioSource.Play();
            isWalking = true;
        }
    }

    void StopGnomeWalkingSound()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
            isWalking = false; 
        }
    }
}





