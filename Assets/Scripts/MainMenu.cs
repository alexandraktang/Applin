using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // whenever you want to load scenes in Unity

public class MainMenu : MonoBehaviour
{
    public void PlayGame() // add in OnClick() in Inspector
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); // gets current scene + 1 (next queued screen)
        Time.timeScale = 1f;
        PauseMenu.GameIsPaused = false;
    }

    public void QuitGame()
    {
        Debug.Log("QUIT"); // just for debugging
        Application.Quit(); // will close an actual app, but not in Unity engine
    }
}
