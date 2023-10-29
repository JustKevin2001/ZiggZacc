using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Sounds")]
    public AudioSource musicSource, sfxSource;
    public AudioClip menuSound;
    public AudioClip gamePlaySound;
    public AudioClip pickUpCoinSound;

    private void Awake()
    {
        MakeInstance();
    }

    public void MakeInstance()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip sound)
    { 
        musicSource.clip = sound;
        musicSource.Play();
    }

    public void PlaySFXMusic(AudioClip sound, float volume)
    {
        sfxSource.PlayOneShot(sound,volume);
    }
}
