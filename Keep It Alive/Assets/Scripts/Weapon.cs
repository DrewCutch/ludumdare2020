using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponProfile WeaponType;

    public void Attack(Transform target)
    {
        WeaponType.Attack(transform, target);
    }
}
