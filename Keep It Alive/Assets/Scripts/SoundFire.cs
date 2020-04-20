using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFire : MonoBehaviour
{
    public enum SoundKind
    {
        Explosion,
        Hit,
        Death,
        Break,
        Heal
    }

    public SoundKind Sound;

    public void Fire()
    {
        SoundManager.MainManager.Play(Sound);
    }
}
