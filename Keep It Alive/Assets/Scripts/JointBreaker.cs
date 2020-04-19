using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointBreaker : MonoBehaviour
{
    public Joint[] joints;

    public Collider[] colliders;

    public void BreakAll()
    {
        foreach (Joint joint in joints)
        {
            Destroy(joint);
        }

        foreach (Collider collider in colliders)
        {
            collider.enabled = true;
        }
    }
}
