using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*Point UI credit: Points counter, HIGH SCORE and display UI in your game - 
 * Score points Unity tutorial, Coco Code*/

//Implemented by (VG)
public class PointSystem : MonoBehaviour
{
    //Instance used in case that PointSystem is needed to be called
    public static PointSystem ps_instance;

    //Sets text to keep track of score
    public Text scoreText;

    //Sets integer to keep track of score, starting at 0
    public int score = 0;

    //Initializes variables for game
    private void Awake()
    {
        ps_instance = this;
    }

    //Updates the text for score
    void Update()
    {
        scoreText.text = "POINTS: " + score.ToString();
    }

    //Adds points to the score
    public void AddPoint(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreText.text = "POINTS: " + score.ToString();
    }
}
