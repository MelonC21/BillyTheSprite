using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Implemented by (MC and VG)
/*
 * This script manages the state of the game and whether it's paused,
 * playing, or in the menu
 */
public class GameStateManager : MonoBehaviour
{
    //List of levels (MC)
    [SerializeField]
    private List<string> m_levels = new List<string>();

    //Scene number variable (VG)
    public static int sceneNumber = 1;
    
    //Name of the title scene  (MC)
    [SerializeField]
    private string m_TitleSceneName; 

    //Name of the loss scene (VG)
    [SerializeField]
    private string m_LossSceneName;

    //How many starting lives the player has (MC)
    [SerializeField]
    private int n_StartingLives;

    //How many current lives the player has (MC)
    public static int n_CurrentLives;

    //variable for the gamestatemanager (MC)
    private static GameStateManager _instance;

    //Sets up the game 
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(_instance);
        }
        else
        {
            Destroy(this);
        }
    }

    //creates a new game and loads you into the first level (MC)
    public static void NewGame()
    {
        n_CurrentLives = _instance.n_StartingLives;
        if (_instance.m_levels.Count > 0)
        {
            SceneManager.LoadScene(_instance.m_levels[0]);
        }
    }
    //Loads you into the title screen (MC)
    public static void QuitToTitle()
    {
        SceneManager.LoadScene(_instance.m_TitleSceneName);
    }

    //Adds points and checks if the game has been won (VG)
    public static void NextLevel()
    {
        sceneNumber += 1;
        SceneManager.LoadScene(_instance.m_levels[GameStateManager.sceneNumber - 1]);
    }

    //Subtracts one life and checks if the player has no lifes left
    //(Initially created by MC modified by VG)
    public static void LifeLoss()
    {
        n_CurrentLives -= 1;
        if (n_CurrentLives <= 0)
        {
            GameStateManager.ToLossScreen();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    //Sends you to the loss screen (VG)
    public static void ToLossScreen()
    {
        SceneManager.LoadScene(_instance.m_LossSceneName);
    }

    //Restarts the current level (VG)
    public static void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
