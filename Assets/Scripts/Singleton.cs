using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public T GetInstance()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<T>();
        }
        else if (instance != FindObjectOfType<T>())
        {
            Destroy(FindObjectOfType<T>());
        }

        DontDestroyOnLoad(this.gameObject);
        return instance;
    }
}