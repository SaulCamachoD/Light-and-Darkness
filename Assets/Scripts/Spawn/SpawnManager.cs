using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject normalEnemy;
    public GameObject strongEnemy;
    public Transform[] spawnPoints1;
    public Transform[] spawnPoints2;
    public float spawnInterval = 30f;
    public bool activateSpawn;
    private void Start()
    {
        activateSpawn = true;
        InitialSpawn();
        StartCoroutine(SpawnEnemies());
    }

    void InitialSpawn()
    {
        
        foreach (Transform spawnPoint in spawnPoints1)
        {
            Instantiate(normalEnemy, spawnPoint.position, spawnPoint.rotation);
        }

        
        foreach (Transform spawnPoint in spawnPoints2)
        {
            Instantiate(strongEnemy, spawnPoint.position, spawnPoint.rotation);
        }
    }
    IEnumerator SpawnEnemies()
    {
        while (activateSpawn) 
        {
            
            yield return new WaitForSeconds(spawnInterval);

            // Spawn de enemigos normales
            foreach (Transform spawnPoint in spawnPoints1)
            {
                Instantiate(normalEnemy, spawnPoint.position, spawnPoint.rotation);
            }

            // Spawn de enemigos fuertes
            foreach (Transform spawnPoint in spawnPoints2)
            {
                Instantiate(strongEnemy, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}
