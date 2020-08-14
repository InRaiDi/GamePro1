using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    

    public void StartGame()
    {
        // Load the first level
        // The okay way -- Error prone due to strings
        // SceneManager.LoadScene("Level1");
        // The better way
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Quit game
    public void QuitGame()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
