using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : UnitySingleton<AudioManager>
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();
        audioSource = GetComponent<AudioSource>();
    }

    public void Play(int id)
    {
        audioSource.PlayOneShot(audioClips[id]);
    }
}
