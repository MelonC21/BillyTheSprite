using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implemented by (MC) and modified by (VG)
//Meant to track Health and Damage 
public class PlayerScript : MonoBehaviour
{
    //Instance used to if playerscript is needed to be called elsewhere (MC)
    public static PlayerScript _PSinstance;

    //Used for speed (MC)
    [SerializeField]
    private float p_speed;

    //Used for the animator (MC)
    private Animator m_Anim;

    //Used for the renderor (MC)
    private SpriteRenderer m_Renderer;

    //Starting health variable (MC)
    [SerializeField]
     private int n_StartingHealth;

    //Starting points variable (VG)
    [SerializeField]
    public int n_StartingPoints;

    //Max point variable (VG)
    [SerializeField]
    private int n_PointThreshold;

    //Current health variable (MC)
    private int n_CurrentHealth;

    //Current points (MC)
    private int n_CurrentPoints;

    // Start is called before the first frame update
    //Sets the starting health
    //Implemented by (MC) and modified by (VG)
    void Start()
    {
        m_Anim = GetComponent<Animator>();
        if (m_Anim != null)
        {
            m_Anim.SetBool("Running", false);
        }
        m_Renderer = GetComponent<SpriteRenderer>();

        n_CurrentHealth = n_StartingHealth;
        n_CurrentPoints = n_StartingPoints;
    }

    //Formerly used in the Player Controller Script
    //Moves the player (MC)
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.1f, 0) * p_speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.1f, 0, 0) * p_speed;
            if (m_Renderer != null)
            {
                // Faces the character to the left
                m_Renderer.flipX = true;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.1f, 0) * p_speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.1f, 0, 0) * p_speed;
            if (m_Renderer != null)
            {
                // Leaves the character facing right
                m_Renderer.flipX = false;
            }
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            m_Anim.SetBool("Running", true);
        }
        else
        {
            m_Anim.SetBool("Running", false);
        }
    }

    //Method used to damage the player and reflect that on the player's health 
    //Implemented by (MC) and modified by (VG)
    public void DamageTaken(int damage)
    {
        Debug.Log("Damaged: " + damage);
        n_CurrentHealth -= damage;
        HealthSystem.h_instance.SubtractDamage(damage);
        if (n_CurrentHealth <= 0)
        {
            GameStateManager.LifeLoss();
        }
    }

    //Method used to add the points (VG)
    public void PointsGained(int points)
    {
        Debug.Log("Point Added: " + points);
        n_CurrentPoints += points;
        if (n_CurrentPoints >= n_PointThreshold)
        {
            GameStateManager.NextLevel();
        }
    }
}
