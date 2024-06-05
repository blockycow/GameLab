using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

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

    void OnEnable() => Collectible.OnCollected += OnCollectibleCollected;
    void OnDisable() => Collectible.OnCollected -= OnCollectibleCollected;

    void OnCollectibleCollected()
    {
        count++;
        UpdateCount();

        if (count == Collectible.total)
        {
            CollectionCompleted?.Invoke();
        }
    }

    [Button]
    public void CompleteCollection()
    {
        text.text = $"Well done!";
        text.color = Color.green;
        CollectionCompleted?.Invoke();
    }

    void UpdateCount()
    {
        text.text = $"{count} / {Collectible.total}";
    }
}
