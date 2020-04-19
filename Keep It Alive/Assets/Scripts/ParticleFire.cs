using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFire : MonoBehaviour
{
    public ParticlePool Pool;

    public void Fire()
    {
        Pool.PlayAt(transform.position);
    }
}
