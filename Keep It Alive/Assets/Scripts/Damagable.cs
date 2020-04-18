﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    [SerializeField]
    private int _health;

    public bool Destroyed { get; private set; }

    public int Health
    {
        get => _health;
        private set => _health = value;
    }

    public event Action OnDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        Destroyed = false;
    }

    public void Damage(int amount)
    {
        Health -= amount;
        if (Health <= 0 && !Destroyed)
        {
            OnDestroyed?.Invoke();
            Destroyed = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}