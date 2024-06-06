using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// The main canvas object.
// -Sandy
public class MainCanvas : MonoBehaviour
{
    // Load the main level scene.
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    // Quit the game.
    public void QuitGame()
    {
        Application.Quit();
    }
}
