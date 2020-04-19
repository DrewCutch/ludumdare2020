using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponProfile", menuName = "ScriptableObjects/WeaponProfile", order = 1)]
public class GrabProfile : ScriptableObject
{
    public float DragStrength;
    public float Damping;
    public float Lift;
}
