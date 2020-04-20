using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int HealAmount;

    void OnTriggerEnter(Collider col)
    {
        col.gameObject.GetComponent<Damagable>()?.Heal(HealAmount);
    }
}
