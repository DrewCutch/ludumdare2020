using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int HealAmount;

    void OnCollisionEnter(Collision col)
    {
        col.gameObject.GetComponent<Damagable>()?.Heal(HealAmount);
    }
}
