using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Damagable>() is Damagable damagable)
            damagable.Damage(int.MaxValue);
    }
}
