using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundAudioPlayer : MonoBehaviour
{
    public List<AudioClip> backgroundAudioClips;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ShuffleNextSong();
    }

    private void ShuffleNextSong()
    {
        audioSource.clip = PickRandomClip();
    }

    private AudioClip PickRandomClip()
    {
        return backgroundAudioClips[Random.Range(0, backgroundAudioClips.Count)];
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            ShuffleNextSong();
            audioSource.Play();
        }
    }
}
