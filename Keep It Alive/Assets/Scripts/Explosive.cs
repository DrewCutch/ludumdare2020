﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float Strength;

    public float DestroyAfter;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explode()
    {
        Collider[] overlapping = Physics.OverlapSphere(transform.position, Strength);
        List<Rigidbody> bodies = overlapping.Select(col => col.gameObject.GetComponent<Rigidbody>()).
            Where(rb => rb != null && rb.gameObject != gameObject).ToList();

        print("exploded!");

        if (gameObject.GetComponent<Renderer>() is Renderer rend)
            rend.enabled = false;

        foreach (Rigidbody body in bodies)
        {
            print("sent body!");

            Vector3 dir = (body.transform.position - transform.position).normalized;

            float distance = (body.transform.position - transform.position).magnitude;

            body.AddForce(dir * Strength *  (1 / distance), ForceMode.Impulse);
        }

        Shaker.MainCameraShaker.ShakeFrom(transform.position, Strength);


        if (DestroyAfter >= 0)
            GameObject.Destroy(gameObject, DestroyAfter);
    }
}
