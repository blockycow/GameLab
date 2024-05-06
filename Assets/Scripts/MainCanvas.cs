using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCanvas : MonoBehaviour
{
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }
}
