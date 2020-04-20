using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Collider))]
public class Damagable : MonoBehaviour
{
    public UnityEvent OnDestroyed;

    public UnityEvent OnDamaged;

    public UnityEvent OnHealed;

    public bool Destroyed { get; private set; }

    public float DamageFromCollision;

    private Collider _collider;

    public int MaxHealth { get; private set; }

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
        MaxHealth = _health;
        
        _collider = gameObject.GetComponent<Collider>();
    }

    public void Damage(int amount)
    {
        if (amount == 0)
            return;

        Health -= amount;
        OnDamaged?.Invoke();
        if (Health <= 0 && !Destroyed)
        {
            print("destroyed!");
            OnDestroyed?.Invoke();
            Destroyed = true;
        }
    }

    public void Heal(int amount)
    {
        if (amount == 0)
            return;

        Health = Mathf.Min(Health + amount, MaxHealth);
        OnHealed?.Invoke();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (DamageFromCollision <= 0)
            return;

        Rigidbody otherRb = collision.gameObject.GetComponent<Rigidbody>();

        float impactStrength = Vector3.Dot(collision.relativeVelocity, collision.contacts[0].normal);

        impactStrength *= impactStrength;

        if (otherRb != null)
            impactStrength *= otherRb.mass;

        Damage((int)(impactStrength * DamageFromCollision));
    }
}
