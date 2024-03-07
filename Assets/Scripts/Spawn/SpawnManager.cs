using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject strongEnemy;
    public Transform[] spawnPoints1;
    public Transform[] spawnPoints2;

    private void Start()
    {
        foreach (Transform spawnPoint in spawnPoints1)
        {
            Instantiate(normalEnemy,spawnPoint);
        }

        foreach (Transform spawnPoint in spawnPoints2)
        {
            Instantiate(strongEnemy, spawnPoint);
        }

    }
}
