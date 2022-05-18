using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceTracker : MonoBehaviour
{
    // singleton:
    public static PlayerReferenceTracker Instance;

    public Transform globalPlayerReference;

    private void Awake()
    {
        // initialize singleton:
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void Update()
    {
        if (globalPlayerReference == null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
                globalPlayerReference = player.transform;
            else
            {
                GameObject spaceship = GameObject.FindWithTag("SpaceshipPlayer");
                if (spaceship != null)
                    globalPlayerReference = spaceship.transform;
            }
        }
    }
}
