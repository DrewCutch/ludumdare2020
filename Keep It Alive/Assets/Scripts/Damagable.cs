using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Damagable : MonoBehaviour
{
    public UnityEvent OnDestroyed;

    public UnityEvent OnDamaged;

    public bool Destroyed { get; private set; }

    public float DamageFromCollision;

    private Collider _collider;

    public int Health
    {
        get => _health;
        private set => _health = value;
    }

    [SerializeField]
    private int _health;

    // Start is called before the first frame update
    void Start()
    {
        Destroyed = false;
        
        _collider = gameObject.GetComponent<Collider>();
    }

    public void Damage(int amount)
    {
        Health -= amount;
        OnDamaged?.Invoke();
        if (Health <= 0 && !Destroyed)
        {
            print("destroyed!");
            OnDestroyed?.Invoke();
            Destroyed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (DamageFromCollision <= 0)
            return;

        Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

        if (otherRb == null)
            return;

        float impactStrength = collision.relativeVelocity.sqrMagnitude * otherRb.mass;

        Damage((int) (impactStrength * DamageFromCollision));
    }
}
