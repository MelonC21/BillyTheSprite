using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Implemeted by (VG)
public class HealthSystem : MonoBehaviour
{
    //Instance used to be called by other scripts if needed
    public static HealthSystem h_instance;

    //Sets text to keep track of lives
    public Text healthText;

    //Sets integer to keep track of health
    public int health;

    //Initializes variables for game
    private void Awake()
    {
        h_instance = this;
    }

    // Start is called before the first frame update
    void Update()
    {
        healthText.text = "Health: " + health.ToString();
    }

    public void SubtractDamage(int damageToTake)
    {
        health -= damageToTake;
        healthText.text = "Health: " + health.ToString();
    }
}
