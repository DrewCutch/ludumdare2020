using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    public ParticleSystem System;

    void Awake()
    {
        System.Play();
    }

    public void PlayAt(Vector3 position)
    {
        print("Play at" + position);
        ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams {position = position, startSize = 1};
        System.Emit(emitParams, 1);
    }
}
