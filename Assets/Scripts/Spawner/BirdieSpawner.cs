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
        if (Input.GetButtonDown("Button-spawn"))
        {
            Instantiate(WhatToSpawn, BirdieSpawnLocation.transform);
            Debug.Log("SpawnBirdie");
        }
    }

    public void BirdieSpawn()
    {
        Instantiate(WhatToSpawn, BirdieSpawnLocation.transform);
        Debug.Log("SpawnBirdie");
    }

}