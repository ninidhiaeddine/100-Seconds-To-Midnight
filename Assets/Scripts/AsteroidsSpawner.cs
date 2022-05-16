using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AsteroidsSpawner : MonoBehaviour
{
    [Header("Required Input")]
    public float timeToSpawn = 10.0f;
    public float distanceFromSpaceship;
    [Range(1, 30)] public int numberOfAsteroidsToSpawnAtATime;
    public List<GameObject> asteroidsPrefabs;

    [Header("Scene Requirement")]
    public Transform spaceshipTransform;

    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    private IEnumerator SpawnAsteroids()
    {
        while(true)
        {
            for (int i = 0; i < numberOfAsteroidsToSpawnAtATime; i++)
            {
                GameObject asteroid = Instantiate(asteroidsPrefabs[Random.Range(0, asteroidsPrefabs.Count)]);
                asteroid.transform.position = ComputeAsteroidPosition();
            }

            yield return new WaitForSeconds(timeToSpawn);
        }
    }

    private Vector3 ComputeAsteroidPosition()
    {
        return spaceshipTransform.position + Random.insideUnitSphere * distanceFromSpaceship;
    }
}
