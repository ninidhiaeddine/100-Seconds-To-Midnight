using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorytellingManager : MonoBehaviour
{
    // singleton:
    public static StorytellingManager Instance { get; private set; }

    // component
    [HideInInspector] public Animator storytellingFSM;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        // initialize component:
        storytellingFSM = GetComponent<Animator>();

        // mark as non destroyable:
        DontDestroyOnLoad(this.gameObject);
    }
}
