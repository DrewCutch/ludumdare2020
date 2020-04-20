using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float Intensity;

    public static Shaker MainCameraShaker;

    void Awake()
    {
        MainCameraShaker = this;
    }

    public void ShakeFrom(Vector3 pos, float intensity)
    {
        Vector3 orthoAdjusted = new Vector3(pos.z, pos.y, pos.z);

        gameObject.GetComponent<Rigidbody>().AddForce((orthoAdjusted - transform.position).normalized * intensity * Intensity, ForceMode.VelocityChange);
    }
}