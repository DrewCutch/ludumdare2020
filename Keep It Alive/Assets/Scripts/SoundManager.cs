using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager MainManager;

    public AudioSource ExplosionSound;

    public AudioSource HitSound;

    public AudioSource KillSound;


    void Awake()
    {
        if(MainManager == null)
            MainManager = this;
    }

    public void Play(SoundFire.SoundKind sound)
    {
        switch (sound)
        {
            case SoundFire.SoundKind.Explosion:
                ExplosionSound.Play();
                break;
            case SoundFire.SoundKind.Hit:
                HitSound.Play();
                break;
            case SoundFire.SoundKind.Death:
                KillSound.Play();
                break;
            case SoundFire.SoundKind.Break:
                break;
            case SoundFire.SoundKind.Heal:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(sound), sound, null);
        }
    }
}
