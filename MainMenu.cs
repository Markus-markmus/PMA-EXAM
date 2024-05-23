using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Constants for scene indexes
    private const int MenuSceneIndex = 0;
    private const int FirstGameSceneIndex = 1; 

    // Method to start the game by loading the next scene
    public void PlayGame()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // Check if the next scene index is within the valid range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogError("Next scene index is out of bounds!");
        }
    }

    // Method to quit the game with a debug log
    public void QuitGame()
    {
        Debug.Log("QuitGame method called - quitting application.");
        Application.Quit();
    }

    // Method to load the main menu scene
    public void LoadMenu()
    {
        SceneManager.LoadScene(MenuSceneIndex);
    }
}