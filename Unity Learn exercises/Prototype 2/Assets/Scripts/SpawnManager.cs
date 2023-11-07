using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[ ] animalPrefabs;
    public int spawnPosZ = 20;
    public int spawnPosX = 15;

    private float startDelay = 2;
    private float spawnInterval = 1.5f; 

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval); 
    }

    void SpawnRandomAnimal() 
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex],
                    new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnPosZ), 
                    animalPrefabs[animalIndex].transform.rotation);
    } 
}
