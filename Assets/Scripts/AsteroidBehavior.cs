using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehavior : MonoBehaviour
{
    /// <summary>
    /// Asteroids naturally fly in the vaccum and rotate by themselves.
    /// This class simulates that effect when attached to an asteroid GameObject.
    /// Also, it self-destroys the asteroid after a given lifetime
    /// </summary>

    // parameters:
    public float flyingSpeed;
    public float rotationSpeed;
    [Range(5.0f, 60.0f)] public float destroyAfter;

    private Vector3 flyingDir;
    private Vector3 rotationAxis;

    void Start()
    {
        // randomizing flying direction:
        flyingDir = Random.insideUnitSphere;
        rotationAxis = Random.insideUnitSphere;

        // self destruction after lifetime expires:
        Destroy(this.gameObject, destroyAfter);
    }

    void Update()
    {
        transform.Translate(flyingDir * flyingSpeed * Time.deltaTime);
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
