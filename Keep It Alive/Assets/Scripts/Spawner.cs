using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Object;

    public Vector3 Velocity;

    public void Spawn()
    {
        GameObject created = Instantiate(Object, transform.position, Quaternion.identity);
        created.GetComponent<Rigidbody>()?.AddForce(Velocity, ForceMode.VelocityChange);
    }
}
