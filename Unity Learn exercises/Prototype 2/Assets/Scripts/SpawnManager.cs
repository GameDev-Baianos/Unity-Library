using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[ ] animalPrefabs;
    int spawnPosX;

    private float startDelay = 2;
    private float spawnInterval = 1.5f; 

    private float[] zBoundaries = {-1.0f, 15.0f};

    void Start()
    {
        InvokeRepeating("SpawnRandomAnimalX", startDelay, spawnInterval); 
        InvokeRepeating("SpawnRandomAnimalLeft", startDelay, spawnInterval);
        InvokeRepeating("SpawnRandomAnimalRight", startDelay, spawnInterval);
    }

    void SpawnRandomAnimalX() 
    {
        int spawnPosZ = 20;
        spawnPosX = 15;
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex],
                    new Vector3(Random.Range(-spawnPosX, spawnPosX), 0, spawnPosZ), 
                    animalPrefabs[animalIndex].transform.rotation);
    } 

    void SpawnRandomAnimalLeft() 
    {
        Vector3 rotation = new Vector3(0, 90, 0);
        spawnPosX = 20;
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex],
                    new Vector3(-spawnPosX, 0, Random.Range(zBoundaries[0], zBoundaries[1])), 
                    Quaternion.Euler(rotation));
    } 

    void SpawnRandomAnimalRight() 
    {
        Vector3 rotation = new Vector3(0, -90, 0);
        spawnPosX = 20;
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        Instantiate(animalPrefabs[animalIndex],
                    new Vector3(spawnPosX, 0, Random.Range(zBoundaries[0], zBoundaries[1])), 
                    Quaternion.Euler(rotation));
    } 
}
