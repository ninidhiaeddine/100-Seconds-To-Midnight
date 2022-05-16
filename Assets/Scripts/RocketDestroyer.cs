using UnityEngine;

public class RocketDestroyer : MonoBehaviour
{
    [Range(1, 120)] public int lifetimeInSeconds = 10;

    void Start()
    {
        Destroy(this.gameObject, lifetimeInSeconds);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Asteroid"))
            Destroy(other.gameObject);

        if (!other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
