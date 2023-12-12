using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Implemented by (MC)
//Is used to spawn the traps and obstacles seen throughout the level
public class SpawnerObject : MonoBehaviour
{
    //List of all the game objects that can be spawned
    public List<GameObject> objectsToSpawn = new List<GameObject>();

    //Boolean to see if the spawns will be random
    public bool isRandomized;

    //Spawns the objects 
    void Start()
    {
        SpawnObject();
    }

    //Spawns the objects at spawnpoints and is randomized
    public void SpawnObject()
    {
        int index = isRandomized ? Random.Range(0, objectsToSpawn.Count) : 0;
        if (objectsToSpawn.Count > 0)
        {
            Instantiate(objectsToSpawn[index], transform.position, transform.rotation);
        }
    }
}
