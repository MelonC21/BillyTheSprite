using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Audio code credit: Unity Tutorial | Coin Pickups, Sound Effects and UI, BeepBoopIndie
//Implemented by (MC) and modified by (VG)
//Script used to calculate the damage an object gives
public class ItemHandler : MonoBehaviour
{
    //Obtains the damage for the object from the scriptable object (MC)
    public ItemSO itemInfo; 

    //Start is called before the first frame update (MC)
    protected int damage_num;

    //Variable for the amount of points an object will do (VG)
    protected int point_num;

    //Boolean to see if damage has been done (MC)
    private bool m_DamageDone = false;

    //The sound used for pickup (VG)
    [SerializeField]
    private AudioClip m_PickupSound;

    //Sets the damage and points an item will do (MC)
    private void Start()
    {
        point_num = itemInfo.points;
        damage_num = itemInfo.damage;
    }

    //Method that damages the player and destroys the damager 
    //Implemented by (MC) and modified by (VG)
    protected virtual void DamageTaken(PlayerScript player)
    {
        player.PointsGained(point_num);
        player.DamageTaken(damage_num);
        Destroy(gameObject);
    }

    //Method that adds the points earned to the score and game (VG)
    protected virtual void PointsGained(PlayerScript player)
    {
        player.PointsGained(point_num);
        Destroy(gameObject);
    }

    //trigger that determines what will happen 
    //Implemented by (MC) and modified by (VG)
    private void OnTriggerEnter2D(Collider2D other)
    {
        //detects if the object is a player
        if (other.gameObject.tag == "Player")
        {
            //if the object that was collided with is an enemy damage will be done
            //Implemented by (MC) and modified by (VG)
            if (itemInfo.enemy == true)
            {
                if (m_DamageDone == true)
                {
                    return;
                }
                PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
                AudioSource.PlayClipAtPoint(m_PickupSound, transform.position);
                DamageTaken(player);
                PointSystem.ps_instance.AddPoint(point_num);
                m_DamageDone = true;
            }
            //if the object was not an enemy points will be added (VG)
            else
            {
                PlayerScript player = other.gameObject.GetComponent<PlayerScript>();
                PointsGained(player);
                PointSystem.ps_instance.AddPoint(point_num);
                AudioSource.PlayClipAtPoint(m_PickupSound, transform.position);
            }
        }
    }
}
