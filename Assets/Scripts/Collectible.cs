using System;
using Sirenix.OdinInspector;
using UnityEngine;

// A common collectible Object that has a total count and a collect event when picked up
// -Matthias
public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;

    public GameObject collectibleObject;
    [SerializeField] private AudioClip clip;

    void Awake() => total++;

    void Update()
    {
        transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    [Button]
    public void Collect()
    {
        AudioManager.Instance.PlaySFX(clip,transform.position);
        OnCollected?.Invoke();
        Destroy(collectibleObject);
    }
}
