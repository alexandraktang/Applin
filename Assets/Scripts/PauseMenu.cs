using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // whenever you want to load scenes in Unity
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    // public because needs to be accessed from other scripts
    // static because we don't want to ref this specific pause menu script; just want to check if paused from other scripts
    public static bool GameIsPaused = false;
    public static bool OptionsMenuOpen = false;

    public GameObject pauseMenuUI; // in order to call the pause menu
    public GameObject optionsMenuUI; // in order to call the pause menu

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) 
            {
                if (OptionsMenuOpen) 
                {
                    SetOptionsInactive();
                    optionsMenuUI.SetActive(false);
                }
                Resume();
            }
            else Pause();
        }
    }

    public void SetOptionsActive() 
    {
        OptionsMenuOpen = true;
    }

    public void SetOptionsInactive() 
    {
        OptionsMenuOpen = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        AudioListener.pause = false;
    }

    // bring up pause menu, freeze time, change GameIsPaused to true
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        AudioListener.pause = true;
    }

    public void QuitGame()
    {
        GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); // gets current scene + 1 (next queued screen)
        AudioListener.pause = false;
    }

}
