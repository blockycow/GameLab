using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

// Class that keeps count of the collected collectibles.
// -Matthias
public class CollectibleCount : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Text text;
    int count;

    public static Action CollectionCompleted;
    
    void Awake()
    {
        if (text != null) return;
        text = GetComponent<TMPro.TMP_Text>();
        text.color = Color.white;
    }

    void Start() => UpdateCount();

    // Add the collected function to the OnCollectedEvent.
    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    //This function is called when a collectible is collected.
    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();

        if (count == Collectible.total)
        {
            CompleteCollection();
        }
    }

    //This editor button is used to simulate what happens when all collectibles are collected.
    [Button]
    public void CompleteCollection()
    {
        Collectible.total = 0;
        text.text = $"Well done!";
        text.color = Color.green;
        CollectionCompleted?.Invoke();
    }

    // Update the text for the player to see the collection progress.
    void UpdateCount()
    {
        text.text = $"{count} / {Collectible.total}";
    }
}
