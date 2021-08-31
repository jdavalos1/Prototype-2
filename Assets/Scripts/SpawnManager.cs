using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 24;
    private float spawnRangeZ = 9;
    private float startDelay = 1;
    private float spawnInterval = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        // Continously spawn animals at the given interval
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Spawn a random animal at a random location on the x axis
    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        float randomHorVertPos = Random.Range(0.0f, 1.0f);
        int yRotAngle = 0;
        // Initally make it random on the X; adding the 1 to z since random spawn for Z smaller
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ + 1);

        // If < 0.5 then we move side-to-side instead of up-to-down
        if (randomHorVertPos < 0.5f)
        {
            int vertLocation = Random.Range(0, 2);
            spawnPos = new Vector3(vertLocation < 1 ? -spawnRangeX : spawnRangeX, 0, Random.Range(-spawnRangeZ, spawnRangeZ));
            yRotAngle = vertLocation < 1 ? -90 : 90;
        }

        // We need to rotate the go recently created without rotating the prefab
        GameObject spawn = Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
        spawn.transform.Rotate(0, yRotAngle, 0);
    }
}
