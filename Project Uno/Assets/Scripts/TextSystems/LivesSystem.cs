using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Implemented by (VG)
public class LivesSystem : MonoBehaviour
{
    //Sets text to keep track of lives
    public Text livesText;

    //Update used to modify the lives text
    void Update()
    {
        livesText.text = "Lives: " + GameStateManager.n_CurrentLives.ToString();
    }
}
