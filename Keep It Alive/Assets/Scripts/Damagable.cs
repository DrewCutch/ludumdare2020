using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
public class Damagable : MonoBehaviour
{
    public UnityEvent OnDestroyed;

    public bool Destroyed { get; private set; }

    public float DamageFromCollision;

    private Collider2D _collider;

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
        
        _collider = gameObject.GetComponent<Collider2D>();
    }

    public void Damage(int amount)
    {
        Health -= amount;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (DamageFromCollision <= 0)
            return;

        Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();

        if (otherRb == null)
            return;

        float impactStrength = collision.relativeVelocity.magnitude * otherRb.mass;

        Damage((int) (impactStrength * DamageFromCollision));
    }
}
