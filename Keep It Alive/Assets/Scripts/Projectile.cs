using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Collider Collider;

    public float EnableColliderAfter;

    public int Damage;

    private float _timeSinceSpawn;

    private bool _activated;

    // Start is called before the first frame update
    void Start()
    {
        _timeSinceSpawn = 0;
        _activated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_activated)
            return;

        _timeSinceSpawn += Time.deltaTime;

        if (_timeSinceSpawn >= EnableColliderAfter)
        {
            Collider.enabled = true;

            _activated = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Damagable damagable = collision.gameObject.GetComponent<Damagable>();

        if (damagable == null)
            return;

        damagable.Damage(Damage);

        Destroy(gameObject);
    }
}
