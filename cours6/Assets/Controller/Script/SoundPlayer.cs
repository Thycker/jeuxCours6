using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    private AudioSource audioSources;
    // Start is called before the first frame update
    void Start()
    {
        audioSources = GetComponent<AudioSource>();      
    }

    public void PlayMusic(audioMusic audioMusic)
    {
        audioSources.clip = audioMusic.songToPlay;
        audioSources.Play();
    }

}
