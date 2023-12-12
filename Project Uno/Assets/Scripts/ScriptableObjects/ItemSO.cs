using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implemented by (MC)
//ScriptableObject in the forms of traps and point giver 
[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    //Determines how much damage an item will deal
    [SerializeField]
    public int damage;

    //Determines if the object is an enemy
    [SerializeField]
    public bool enemy;

    [SerializeField]
    public int points; 
}
