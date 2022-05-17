using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorytellingNotifier : MonoBehaviour
{
    public bool playOnAwake = true;
    public string key;
    public int value;

    void Start()
    {
        if (playOnAwake)
            Notify();
    }

    public void Notify()
    {
        StorytellingManager.Instance.storytellingFSM.SetInteger(key, value);
    }
}
