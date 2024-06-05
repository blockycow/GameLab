using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  A reusable Singleton class, able to be referenced from anywhere after calling the GetInstance() method
// -Nemo
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance;

    public T GetInstance()
    {
        if (Instance == null)
        {
            Instance = FindObjectOfType<T>();
        }
        else if (Instance != FindObjectOfType<T>())
        {
            Destroy(FindObjectOfType<T>());
        }

        DontDestroyOnLoad(this.gameObject);
        return Instance;
    }
}