using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCutsceneMovement : MonoBehaviour
{
    public float rotationSpeed;
    public float durationBeforeSpawning;
    public float durationBetweenSpawning;
    public GameObject galaxyPrefab;
    public Transform spawningPosition;

    private void Start()
    {
        StartCoroutine(SpawnGalaxies());
    }

    void Update()
    {
        transform.Rotate(transform.up, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator SpawnGalaxies()
    {
        yield return new WaitForSeconds(durationBeforeSpawning);
        while (true)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject galaxy = Instantiate(galaxyPrefab);
                galaxy.transform.position = spawningPosition.position;
            }
            yield return new WaitForSeconds(durationBetweenSpawning);
        }
    }
}
