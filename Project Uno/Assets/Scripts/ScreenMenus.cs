using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Pause Menu credit: PAUSE MENU in Unity, Brackeys
//Implemented by (MC) and modified by (VG)
public class ScreenMenus : MonoBehaviour
{
    //Boolean to check if the game is paused
    public static bool GameIsPaused = false;

    //Gameobject that holds the pause menu
    public GameObject pauseMenuUI;

    //Checks if the escape key is pressed to pause the game
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                OnClickResume();
            }
            else
            {
                OnClickPause();
            }
        }
    }

    //Starts a new game (MC)
    public void OnClickNewGame()
    {
        Time.timeScale = 1f;
        if(GameIsPaused)
        {
            GameIsPaused = false;
        }
        GameStateManager.NewGame();
    }

    //This will exit the application (MC)
    public void OnClickQuitGame()
    {
        Application.Quit();
    }

    //This is now used for the winner screen to send the player to the main menu (MC)
    public void OnClickPlayAgain()
    {
        GameStateManager.sceneNumber = 1;
        GameStateManager.QuitToTitle();
    }

    //Resumes the game after being paused (VG)
    public void OnClickResume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    //Pauses the game after clicking esc (VG)
    public void OnClickPause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    //Restarts the current level (VG)
    public void OnClickRestart()
    {
        OnClickResume();
        GameStateManager.RestartLevel();
    }
}
