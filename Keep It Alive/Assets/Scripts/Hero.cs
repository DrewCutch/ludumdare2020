﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ForceMotor))]
[RequireComponent(typeof(Actor))]
public class Hero : MonoBehaviour
{
    public Transform TopOfScreen;

    private ForceMotor _motor;

    // Start is called before the first frame update
    void Start()
    {
        _motor = gameObject.GetComponent<ForceMotor>();
        _motor.SetTarget(TopOfScreen, 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
