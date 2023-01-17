using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdieSpawner : MonoBehaviour
{
    

    public GameObject WhatToSpawn;

    public GameObject BirdieSpawnLocation;

   /* public void ButtonDown()
    {
       // birdie();
    }
   */
    public void Update()
    {
        if (Input.GetKeyDown("k"))
        {
            Instantiate(WhatToSpawn, BirdieSpawnLocation.transform);
            Debug.Log("SpawnBirdie");
        }
    }


}