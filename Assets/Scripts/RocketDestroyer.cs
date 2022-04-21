using UnityEngine;

public class RocketDestroyer : MonoBehaviour
{
    [Range(1, 300)] public int lifetimeInSeconds = 10;

    void Start()
    {
        Destroy(this.gameObject, lifetimeInSeconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit a collider!" + other.name);
            Destroy(this.gameObject);
        }
    }
}
