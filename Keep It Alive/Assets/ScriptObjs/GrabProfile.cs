using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GrabProfile", menuName = "ScriptableObjects/GrabProfile", order = 1)]
public class GrabProfile : ScriptableObject
{
    public float DragStrength;
    public float AlignStrength;
    public float Damping;
    public float Lift;
}
